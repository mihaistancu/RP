using System.IO.Compression;
using RP.Services.Dependencies;

namespace RP.Services;

public class AddSedMetadata
{
    public async Task ExecuteAsync(Stream package)
    {
        using (ZipArchive archive = new ZipArchive(package, ZipArchiveMode.Read))
        
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            await Context.Seds.AddAsync(entry.Name, entry.Open());
        }
    }
}