namespace RP.Services.Dependencies;

public interface ILabelRepository
{
    Task SaveAsync(string name, Stream stream);
}