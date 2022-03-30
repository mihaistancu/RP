using System.IO.Compression;
using RP.Entities;
using RP.Services.Dependencies;

namespace RP.Services;

public class AddSedMetadata
{
    private SedMetadataParser parser = new SedMetadataParser();

    public void Execute(Stream package)
    {
        using (ZipArchive archive = new ZipArchive(package, ZipArchiveMode.Read))
        
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            var reader = new StreamReader(entry.Open());
            var metadata = reader.ReadToEnd(); 
            var parsed = parser.Parse(metadata);
            var sedToAdd = new SedToAdd(parsed.Sector, parsed.Code, parsed.Version, metadata, "Draft");
            Context.Seds.Add(sedToAdd);
        }
    }
}

public record SedToAdd(string Sector, string Code, string Version, string Metadata, string Status);