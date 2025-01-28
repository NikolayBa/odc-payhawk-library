using Without.Systems.Payhawk.Structures;

namespace Without.Systems.Payhawk.Test;

public class Tests
{
    private static readonly IPayhawk _actions = new Payhawk();

    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void Valid_Signature()
    {
        string publicKey =
            @"ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC9UKhn25PWQPE49lRWGZZde/o8MfmGPcvUKvZMwMEo33Fo6iHv6B8igLDqzuQ1L25CI2uixlRayce+/7v4Cv1JrXv9g9pqTv6uv7Cxk9Zjfa+ArMSTYzTx1Bxhz1dqli+oXxZP5/H+gTkz5AUFg0BAzWZYcSc5+YVU80wo3238mZz3w8dbXojb2uA9ey2BoQDitfTXQaammTiVgl1HMkWDMk/EQiQHoVrgfPtah48A7GF2mYWYeJnUxz38el90T9QAXUsT8JIi1D/UwQghF4Wcg6hH0XdxQWeUZ+LuUoLo1KJuAkUG9eiIRB6K/FpV290OOsDl/HPOvHBV7wpLlabZeHXM0fKYTkUDBy45AXGst9Z5q5vRCVgTOM4dOn6o4vsOTb5rBGpJff9O/3JC70jbEBmSRnxUNaDhJt/P3O+SLfG1iMfaxTdhqECX/3KY+gFqxnztAGUp6wz27d2uw5fpw4Ypd7GT5cIObjHglB9lYrq+3m/okuNOgDnNGtz/M2M= payhawk";
        
        string payload =
            @"{""id"":""326913"",""accountId"":""telelink_business_services_partner_s_20805aba_demo"",""eventType"":""expense.created"",""payload"":{""expenseId"":""43""}}";
        string signature = "tRy+jhVyHfoLllDBKAMt7y30psl++DYBngBQcYEfC8bb9y72GsmOpFJGDpXfhnq6ZxIOyx0IN+dMHv/DczpYGDYXSDg231s5qZXfNiS5HJjRcTAM4O4FwseOGv+Ns8u1sl4UPKb+CETiHAobC7ygpp2QvcWc9YpEBaGgh9trB48N07SK3ugfjlo8eSdeQDpG+CY1dR+pdLQznZhw9nsCkV0SlmrR8JDg43YFZjw+2qmpGGhrvtE6d6gqPtvjrx6TJR/VGWBeCv0duZcK8pJPckfZErnreIowlEyEXLtIE3Nsz4kEteiEXjHK+M84S6fheFfhOTAtclRdtPMmOuI1N8TB0uxTtLzmP4UStDg7eOypM76MUQepkIfQcovyZoTqBdvacPjycFZPYoJksVWhPnjVf/0fp2pIivD3jDmWXVkML5P9y7NsXakczSjiMN7s5cNdzc/N6FI0zqFhlYksYdl7TqoJHKySMHTCwHTpX9JU+mZXOOuCcYbVUJXS3PKo";
        string timestamp = "2024-06-09T04:48:23.193Z";
        string url = "/6f0eef23-52c0-4ddc-8043-dc620c973ba2";


        byte[] signatureBytes = Convert.FromBase64String(signature);

        VerifySignatureRequest request = new VerifySignatureRequest
        {
            PublicKey = publicKey,
            Payload = payload,
            Signature = signature,
            Timestamp = timestamp,
            WebhookUrl = url
        };

        var result = _actions.VerifySignature(request);

        Assert.That(result.Valid, Is.True);
    }
    
}
