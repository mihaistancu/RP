using RP.UseCases.Dependencies;

namespace RP.Db;

public class SedRepository: ISedRepository
{
    private const string MetadataPath = "c:\\temp\\Metadata";

    public async Task SaveAsync(string name, Stream stream) 
    {
        var path = Path.Combine(MetadataPath, name);
        var fileStream = File.Create(path);
        await stream.CopyToAsync(fileStream);
        fileStream.Close();
    }
}
