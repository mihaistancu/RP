using System.IO.Compression;

public class AddSedMetadata
{
    private const string MetadataPath = "c:\\temp\\Metadata";

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