namespace RP.Services;

using RP.Services.Dependencies;

public class DeleteSedMetadata
{
    public void Execute(DeleteSedMetadataRequest request)
    {
        Context.Seds.Delete(request.Seds);
    }
}

public record DeleteSedMetadataRequest(List<SedToDelete> Seds);

public record SedToDelete(string Code, string Version);