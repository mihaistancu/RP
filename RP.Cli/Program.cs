using System.IO.Compression;
using System.Net;

var memoryStream = new MemoryStream();

using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))

foreach (var file in Directory.GetFiles(args[0]))
{
    archive.CreateEntryFromFile(file, Path.GetFileName(file));
}

memoryStream.Seek(0, SeekOrigin.Begin);

var httpClientHandler = new HttpClientHandler();
httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;
var client = new HttpClient(httpClientHandler);

var content = new StreamContent(memoryStream);
content.Headers.Add("Content-Type", "application/zip");

var url = "https://localhost:7194/api/seds/metadata";

var response = await client.PutAsync(url, content);
response.EnsureSuccessStatusCode();