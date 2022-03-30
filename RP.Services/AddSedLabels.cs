using System.IO.Compression;
using RP.Entities;
using RP.Services.Dependencies;

namespace RP.Services;

public class AddSedLabels
{
    private SedLabelsParser parser = new SedLabelsParser();

    public void Execute(Stream package)
    {
        using (ZipArchive archive = new ZipArchive(package, ZipArchiveMode.Read))
        
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            var reader = new StreamReader(entry.Open());
            var content = reader.ReadToEnd(); 
            var parsed = parser.Parse(content);
            var labelsToAdd = new LabelsToAdd(parsed.Code, parsed.Version, parsed.Country, parsed.Language, content);
            Context.Labels.Add(labelsToAdd);
        }
    }
}

public record LabelsToAdd(string Code, string Version, string Country, string Language, string Content);