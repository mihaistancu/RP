using RP.Entities;

namespace RP.Services.Dependencies;

public interface ISedRepository 
{
    List<ManifestItem> GetManifest();

    void Add(SedToAdd sed);

    void Delete(List<SedToDelete> seds);
    
    string GetMetadata(string sedCode, string sedVersion);

    void SetStatus(List<SedToUpdate> seds, string status);
}