using RP.Services.Dependencies;

namespace RP.Services;

public class GetSedManifest
{
    public async Task<List<ManifestItem>> ExecuteAsync()
    {
        return await Context.Seds.GetManifest();
    }
}

public record ManifestItem(string Sector, string Code, string Version, string Status);