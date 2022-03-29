namespace RP.UseCases;

public class GetSedLabels
{
    public Stream Execute(string sed, string version, string country, string language)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write( @$"{{""sed"":""{sed}"", ""version"": ""{version}""}}");
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
}