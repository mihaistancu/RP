using System.IO.Compression;
using RP.Entities;
using RP.Services.Dependencies;

namespace RP.Services;

public class AddSedMetadata
{
    private SedParser sedParser = new SedParser();

    public void Execute(Stream package)
    {
        using (ZipArchive archive = new ZipArchive(package, ZipArchiveMode.Read))
        
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            var reader = new StreamReader(entry.Open());
            var metadata = reader.ReadToEnd(); 
            var sed = sedParser.Parse(metadata);
            Context.Seds.Add(sed, metadata);
        }
    }
}