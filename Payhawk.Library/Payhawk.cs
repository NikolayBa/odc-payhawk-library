using System.Security.Cryptography;
using System.Text;
using Without.Systems.Payhawk.Extensions;
using Without.Systems.Payhawk.Structures;

namespace Without.Systems.Payhawk;

public class Payhawk : IPayhawk
{

    public VerifySignatureResponse VerifySignature(VerifySignatureRequest verifySignatureRequest)
    {
        byte[] signatureBytes = Convert.FromBase64String(verifySignatureRequest.Signature);
        
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            
            RSAParameters p = ExportRsaParameters(verifySignatureRequest.PublicKey);
            rsa.ImportParameters(p);
            
            string dataToVerify =
                $"{verifySignatureRequest.Timestamp}:{verifySignatureRequest.WebhookUrl}:{verifySignatureRequest.Payload}";

            bool isValid = rsa.VerifyData(Encoding.UTF8.GetBytes(dataToVerify), signatureBytes, HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);
            
            return new VerifySignatureResponse
            {
                Valid = isValid
            };

        }
    }
    
    
    /// <summary>
    /// Extracts Exponent and Modules from the openssh rsa public key and returns a RSAParameters structure.
    /// </summary>
    /// <param name="publicKey">Public Key as retrieved from the Public Key Payhawk endpoint</param>
    /// <returns>RSAParameters</returns>
    /// <exception cref="ArgumentException"></exception>
    private RSAParameters ExportRsaParameters(string publicKey)
    {
        string[] keyParts = publicKey.Split(' ');
        if (keyParts.Length != 3) throw new ArgumentException("Invalid Public Key");

        string base64Part = keyParts[1];

        // Convert the base64 string to bytes
        byte[] keyBytes = Convert.FromBase64String(base64Part);
        
        using (MemoryStream ms = new MemoryStream(keyBytes))
        using (BinaryReader br = new BinaryReader(ms))
        {
            int headerLength = br.ReadInt32BigEndian();
            br.ReadBytes(headerLength);
            int exponentLength = br.ReadInt32BigEndian();
            
            byte[] exponent = br.ReadBytes(exponentLength);
            
            int modulusLength = br.ReadInt32BigEndian();

            // Skip Signing Byte. RSAParameters expect a modulus without the Signing Byte.
            
            br.ReadByte();
            // Length of modulus is equal to the signature size.
            byte[] modulus = br.ReadBytes(modulusLength - 1);
            

            return new RSAParameters
            {
                Exponent = exponent,
                Modulus = modulus
            };
        }
        
        
    }
}