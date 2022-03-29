namespace RP.UseCases.Dependencies;

public interface ISedRepository 
{
    Task SaveAsync(string name, Stream stream);
}