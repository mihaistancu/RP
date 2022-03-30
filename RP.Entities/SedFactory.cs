using Newtonsoft.Json.Linq;

namespace RP.Entities;

public class SedParser
{
    public Sed Parse(String metadata)
    {
        dynamic json = JObject.Parse(metadata);

        var code = (string)json.context.inputs.sedName;
        var version = $"{json.context.inputs.sedGVer}.{json.context.inputs.sedVer}.{json.context.inputs.sedPatchVer}";
        var sector = ((string)json.context.inputs.sedPackage).Split('/')[1];
        var status = "Draft";

        return new Sed(code, version, sector, status);
    }
}