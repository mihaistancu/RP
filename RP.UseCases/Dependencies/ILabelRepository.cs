namespace RP.UseCases.Dependencies;

public interface ILabelRepository
{
    Task SaveAsync(string name, Stream stream);
}