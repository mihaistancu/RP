using RP.UseCases;
using RP.UseCases.Dependencies;

namespace RP.Db;

public class SedRepository: ISedRepository
{
    private const string MetadataPath = "c:\\temp\\Metadata";

    public async Task AddAsync(string name, Stream stream) 
    {
        var path = Path.Combine(MetadataPath, name);
        var fileStream = File.Create(path);
        await stream.CopyToAsync(fileStream);
        fileStream.Close();
    }

    public async Task DeleteAsync(List<SedToDelete> seds)
    {
        throw new NotImplementedException();
    }

    public async Task SetStatusAsync(List<SedToUpdate> seds, string status)
    {
        throw new NotImplementedException();
    }
}
