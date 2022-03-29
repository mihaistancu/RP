namespace RP.Services.Dependencies;

public interface ISedRepository 
{
    Task AddAsync(string name, Stream stream);

    Task DeleteAsync(List<SedToDelete> seds);

    Task SetStatusAsync(List<SedToUpdate> seds, string status);
}