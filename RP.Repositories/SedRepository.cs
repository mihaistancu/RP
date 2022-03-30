using RP.Entities;
using RP.Services;
using RP.Services.Dependencies;

namespace RP.Repositories;

public class SedRepository: ISedRepository
{
    private List<InMemoryRecord> db = new List<InMemoryRecord>();

    public async Task<List<ManifestItem>> GetManifest()
    {
        var manifest = db.Select(r => new ManifestItem(r.Sector, r.Code, r.Version, r.Status)).ToList();
        return await Task.FromResult(manifest);
    }

    public async Task AddAsync(Sed sed, String metadata) 
    {
        db.Add(new InMemoryRecord(sed.Sector, sed.Code, sed.Version, sed.Status, metadata));
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(List<SedToDelete> seds)
    {
        foreach (var sed in seds)
        {
            db.RemoveAll(r => r.Code == sed.Code && r.Version == sed.Version);
        }
        await Task.CompletedTask;
    }

    public async Task SetStatusAsync(List<SedToUpdate> seds, string status)
    {
        foreach (var sed in seds)
        {
            db.Single(r=>r.Code == sed.Code && r.Version == sed.Version).Status = status;
        }
        await Task.CompletedTask;
    }

    public async Task<String> GetMetadata(string sedCode, string sedVersion)
    {
        var metadata = db.Single(r=>r.Code == sedCode && r.Version == sedVersion).Metadata;
        return await Task.FromResult(metadata);
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