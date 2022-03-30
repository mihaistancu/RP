using RP.Entities;
using RP.Services;
using RP.Services.Dependencies;

namespace RP.Repositories;

public class SedRepository: ISedRepository
{
    private const string MetadataPath = "c:\\temp\\Metadata";

    public async Task<List<ManifestItem>> GetManifest()
    {
        var manifest = new List<ManifestItem>();

        foreach (var file in Directory.GetFiles(MetadataPath))
        {
            var tokens = Path.GetFileName(file).Split('_');
            manifest.Add(new ManifestItem(tokens[0], tokens[1], tokens[2], tokens[3]));
        }

        return await Task.FromResult(manifest);
    }

    public async Task AddAsync(Sed sed, String metadata) 
    {
        var path = $@"{MetadataPath}\{sed.Sector}_{sed.Code}_{sed.Version}_{sed.Status}";
        await File.WriteAllTextAsync(path, metadata);
    }

    public async Task DeleteAsync(List<SedToDelete> seds)
    {
        foreach (var sed in seds)        
        foreach (var file in Directory.EnumerateFiles($"{MetadataPath}\\*_{sed.Code}_{sed.Version}_*"))
        {
            File.Delete(file);
        }   
        await Task.CompletedTask;
    }

    public async Task SetStatusAsync(List<SedToUpdate> seds, string status)
    {
        foreach (var sed in seds)        
        foreach (var file in Directory.EnumerateFiles($"{MetadataPath}\\*_{sed.Code}_{sed.Version}_*"))
        {
            var newFile = file.Substring(0, file.LastIndexOf("_") + 1) + status;

            File.Move(file, newFile);
        }   
        await Task.CompletedTask;
    }
}
