namespace RP.Services.Dependencies;

public interface ILabelRepository
{
    void Add(LabelsToAdd labels);
    string Get(string code, string version, string country, string language);
}