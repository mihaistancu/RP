using System.IO.Compression;
using RP.Services.Dependencies;

namespace RP.Services;

public class AddSedLabels
{
    public async Task ExecuteAsync(Stream package)
    {
        using (ZipArchive archive = new ZipArchive(package, ZipArchiveMode.Read))
        
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            await Context.Labels.SaveAsync(entry.Name, entry.Open());
        }
    }
}