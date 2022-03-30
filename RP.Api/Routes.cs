using RP.Services;

namespace RP.Api;

public static class Routes 
{
    public static void AddRoutes(this WebApplication app)
    {
        app.MapGet("/api/seds/manifest", async () =>
        {
            var useCase = new GetSedManifest();
            var manifest = await useCase.ExecuteAsync();
            return Results.Ok(manifest);
        });

        app.MapGet("/api/seds/{sedCode}/{sedVersion}/metadata", 
            (string sedCode, string sedVersion) => {
                var useCase = new GetSedMetadata();
                var metadata = useCase.Execute(sedCode, sedVersion);
                return Results.Stream(metadata, @"application\json");
            });

        app.MapGet("/api/seds/{sedCode}/{sedVersion}/labels/{country}/{language}", 
            (string sedCode, string sedVersion, string country, string language) => {
                var useCase = new GetSedLabels();
                var metadata = useCase.Execute(sedCode, sedVersion, country, language);
                return Results.Stream(metadata, @"application\json");
            });

        app.MapPost("/api/seds/batch/update-status",  
            (SetSedStatusRequest request) => {
                var useCase = new SetSedStatus();
                useCase.Execute(request);
                return Results.Ok();
            });

        app.MapPost("/api/seds/batch/delete-metadata",
            async (DeleteSedMetadataRequest request) => {
                var useCase = new DeleteSedMetadata();
                await useCase.ExecuteAsync(request);
                return Results.Ok();
            });

        app.MapPut("/api/seds/metadata",
            async (IFormFile file) => {
                var useCase = new AddSedMetadata();
                await useCase.ExecuteAsync(file.OpenReadStream());
                return Results.Ok();
            })
            .Accepts<IFormFile>("multipart/form-data");

        app.MapPut("/api/seds/labels",
            async (IFormFile file) => {
                var useCase = new AddSedLabels();
                await useCase.ExecuteAsync(file.OpenReadStream());
                return Results.Ok();
            })
            .Accepts<IFormFile>("multipart/form-data");
    }
}