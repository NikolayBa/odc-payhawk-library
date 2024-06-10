using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Payhawk.Structures;

[OSStructure(Description = "Request for verifying a Payhawk Webhook signature")]
public struct VerifySignatureRequest
{
    [OSStructureField(Description = "Public Key retrieved from the Public Key Payhawk API Endpoint",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string PublicKey;
    
    [OSStructureField(Description = "Signature to be verified",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Signature;
    
    [OSStructureField(Description = "Timestamp from X-Payhawk-Timestamp",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Timestamp;
    
    [OSStructureField(Description = "The webhook URL",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string WebhookUrl;
    
    [OSStructureField(Description = "Payload to be verified",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Payload;
}