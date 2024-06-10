using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Payhawk.Structures;

[OSStructure(Description = "Result object of Verify Signature")]
public struct VerifySignatureResponse
{
    [OSStructureField(Description = "Indicates if the signature could be validated.",
        DataType = OSDataType.Boolean)]
    public bool Valid;
}