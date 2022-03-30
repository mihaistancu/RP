using RP.Entities;
using RP.Services;
using RP.Services.Dependencies;

namespace RP.Repositories;

public class SedRepository: ISedRepository
{
    private record InMemoryRecord(string Sector, string Code, string Version, string Metadata)
    {
        public string Status {get;set;}
    }

    private List<InMemoryRecord> db = new List<InMemoryRecord>();

    public List<ManifestItem> GetManifest()
    {
        return db.Select(r => new ManifestItem(r.Sector, r.Code, r.Version, r.Status)).ToList();        
    }

    public void Add(SedToAdd sed) 
    {
        db.Add(new InMemoryRecord(sed.Sector, sed.Code, sed.Version, sed.Metadata){Status = sed.Status});        
    }

    public void Delete(List<SedToDelete> seds)
    {
        foreach (var sed in seds)
        {
            db.RemoveAll(r => r.Code == sed.Code && r.Version == sed.Version);
        }
    }

    public void SetStatus(List<SedToUpdate> seds, string status)
    {
        foreach (var sed in seds)
        {
            db.Single(r=>r.Code == sed.Code && r.Version == sed.Version).Status = status;
        }
    }

    public string GetMetadata(string sedCode, string sedVersion)
    {
        return db.Single(r=>r.Code == sedCode && r.Version == sedVersion).Metadata;
    }
}