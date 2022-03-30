using RP.Entities;

namespace RP.Services.Dependencies;

public interface ISedRepository 
{
    Task<List<ManifestItem>> GetManifest();

    Task AddAsync(Sed sed, String metadata);

    Task DeleteAsync(List<SedToDelete> seds);
    
    Task<String> GetMetadata(string sedCode, string sedVersion);

    Task SetStatusAsync(List<SedToUpdate> seds, string status);
}