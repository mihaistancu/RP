using RP.Entities;
using RP.Services;
using RP.Services.Dependencies;

namespace RP.Repositories;

public class SedRepository: ISedRepository
{
    private List<InMemoryRecord> db = new List<InMemoryRecord>();

    public List<ManifestItem> GetManifest()
    {
        return db.Select(r => new ManifestItem(r.Sector, r.Code, r.Version, r.Status)).ToList();        
    }

    public void Add(Sed sed, String metadata) 
    {
        db.Add(new InMemoryRecord(sed.Sector, sed.Code, sed.Version, sed.Status, metadata));        
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

    private class InMemoryRecord 
    {
        public string Sector {get;set;}
        public string Code {get;set;}
        public string Version {get;set;}
        public string Status {get;set;}
        public string Metadata {get;set;}

        public InMemoryRecord(string sector, string code, string version, string status, string metadata)
        {
            Sector = sector;
            Code = code;
            Version = version;
            Status = status;
            Metadata = metadata;
        }
    }
}