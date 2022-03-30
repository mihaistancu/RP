using RP.Services.Dependencies;

namespace RP.Services;

public class GetSedLabels
{
    public String Execute(string code, string version, string country, string language)
    {
        return Context.Labels.Get(code, version, country, language);
    }
}