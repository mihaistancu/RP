using Newtonsoft.Json.Linq;

namespace RP.Entities;

public class SedLabelsParser
{
    public SedLabels Parse(string labels)
    {
        dynamic json = JObject.Parse(labels);

        var code = (string)json.sedName;
        var version = (string)json.sedVersion;
        var country = (string)json.country;
        var language = (string)json.language;
        
        return new SedLabels(code, version, country, language, labels);
    }
}