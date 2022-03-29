using System.IO.Compression;

namespace RP.UseCases;

public class AddSedLabels
{
    private const string MetadataPath = "c:\\temp\\Labels";

    public void Execute(Stream package)
    {
        using (ZipArchive archive = new ZipArchive(package, ZipArchiveMode.Read))
        
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            if (entry.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            {
                string destinationPath = Path.GetFullPath(Path.Combine(MetadataPath, entry.Name));
                entry.ExtractToFile(destinationPath);
            }
        }
    }
}