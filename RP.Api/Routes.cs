using RP.Services;

namespace RP.Api;

public static class Routes 
{
    public static void AddRoutes(this WebApplication app)
    {
        app.MapGet("/api/seds/manifest", () =>
        {
            var useCase = new GetSedManifest();
            var manifest = useCase.Execute();
            return Results.Ok(manifest);
        });

        app.MapGet("/api/seds/{sedCode}/{sedVersion}/metadata", 
            (string sedCode, string sedVersion) => {
                var useCase = new GetSedMetadata();
                var metadata = useCase.Execute(sedCode, sedVersion);
                return RawJson(metadata);
            });

        app.MapGet("/api/seds/{sedCode}/{sedVersion}/labels/{country}/{language}", 
            (string sedCode, string sedVersion, string country, string language) => {
                var useCase = new GetSedLabels();
                var labels = useCase.Execute(sedCode, sedVersion, country, language);
                return RawJson(labels);
            });

        app.MapPost("/api/seds/batch/update-status",  
            (SetSedStatusRequest request) => {
                var useCase = new SetSedStatus();
                useCase.Execute(request);
                return Results.Ok();
            });

        app.MapPost("/api/seds/batch/delete-metadata",
            (DeleteSedMetadataRequest request) => {
                var useCase = new DeleteSedMetadata();
                useCase.Execute(request);
                return Results.Ok();
            });

        app.MapPut("/api/seds/metadata",
            (IFormFile file) => {
                var useCase = new AddSedMetadata();
                useCase.Execute(file.OpenReadStream());
                return Results.Ok();
            });

        app.MapPut("/api/seds/labels",
            (IFormFile file) => {
                var useCase = new AddSedLabels();
                useCase.Execute(file.OpenReadStream());
                return Results.Ok();
            });
    }

    private static IResult RawJson(string json)
    {
        var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
        return Results.Stream(stream, @"application\json");
    }
}