namespace RP.Services;

using RP.Services.Dependencies;

public class DeleteSedMetadata
{
    public async Task ExecuteAsync(DeleteSedMetadataRequest request)
    {
        await Context.Seds.DeleteAsync(request.Seds);
    }
}

public record DeleteSedMetadataRequest(List<SedToDelete> Seds);

public record SedToDelete(string Code, string Version);