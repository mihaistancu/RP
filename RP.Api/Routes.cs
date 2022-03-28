public static class WebApplicationRoutes 
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
            (DeleteSedMetadataRequest request) => {
                var useCase = new DeleteSedMetadata();
                useCase.Execute(request);
                return Results.Ok();
            });

        app.MapPut("/api/seds/metadata",
            WithUpload(package => {
                var useCase = new AddSedMetadata();
                useCase.Execute(package);
                return Results.Ok();
            }));

        app.MapPut("/api/seds/labels",
            WithUpload(package => {
                var useCase = new AddSedLabels();
                useCase.Execute(package);
                return Results.Ok();
            }));
    }

    private static Action<HttpRequest> WithUpload(Func<Stream, IResult> handler) 
    {
        return (HttpRequest request) => {
            var stream = request.Form.Files.Single().OpenReadStream();
            handler(stream);
        };
    }
}