using RP.Services.Dependencies;

namespace RP.Services;

public class GetSedMetadata
{
    public String Execute(string code, string version)
    {
        return Context.Seds.GetMetadata(code, version);
    }
}