using RP.Services.Dependencies;

namespace RP.Services;

public class GetSedManifest
{
    public List<ManifestItem> Execute()
    {
        return Context.Seds.GetManifest();
    }
}

public record ManifestItem(string Sector, string Code, string Version, string Status);