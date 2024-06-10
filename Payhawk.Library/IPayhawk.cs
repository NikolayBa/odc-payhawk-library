using OutSystems.ExternalLibraries.SDK;
using Without.Systems.Payhawk.Structures;

namespace Without.Systems.Payhawk
{
    [OSInterface(
        Name = "Payhawk",
        Description = "Payhawk Integration Utility Actions")]
    public interface IPayhawk
    {
        [OSAction(Description = "Verifies a Payhawk Signature",
            ReturnName = "result",
            ReturnDescription = "Signature Validation Result")]
        VerifySignatureResponse VerifySignature(
            [OSParameter(Description = "Verify Signature Request",
                DataType = OSDataType.InferredFromDotNetType)]
            VerifySignatureRequest verifySignatureRequest);
    }
}