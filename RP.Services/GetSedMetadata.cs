using RP.Services.Dependencies;

namespace RP.Services;

public class GetSedMetadata
{
    public String Execute(string sed, string version)
    {
        return Context.Seds.GetMetadata(sed, version);
    }
}