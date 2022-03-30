using RP.Services.Dependencies;

namespace RP.Services;

public class GetSedMetadata
{
    public async Task<String> ExecuteAsync(string sed, string version)
    {
        return await Context.Seds.GetMetadata(sed, version);
    }
}