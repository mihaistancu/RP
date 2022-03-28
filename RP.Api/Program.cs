var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/sed-manifest", () =>
{
    var useCase = new GetSedManifest();
    var manifest = useCase.Execute();
    return Results.Ok(manifest);
});

app.MapGet("/api/sed/{sedCode}/{sedVersion}/metadata", 
    (string sedCode, string sedVersion) => {
        var useCase = new GetSedMetadata();
        var metadata = useCase.Execute(sedCode, sedVersion);
        return Results.Stream(metadata, @"application\json");
    });

app.MapGet("/api/sed/{sedCode}/{sedVersion}/labels/{country}/{language}", 
    (string sedCode, string sedVersion, string country, string language) => {
        var useCase = new GetSedLabels();
        var metadata = useCase.Execute(sedCode, sedVersion, country, language);
        return Results.Stream(metadata, @"application\json");
    });

app.MapPut("/api/sed/{sedCode}/{sedVersion}", 
    (string sedCode, string sedVersion, SetSedStatusRequest request) => {
        var useCase = new SetSedStatus();
        useCase.Execute(sedCode, sedVersion, request.status);
        return Results.Ok();
    });

app.MapDelete("/api/sed/{sedCode}/{sedVersion}/metadata",
    (string sedCode, string sedVersion) => {
        var useCase = new DeleteSedMetadata();
        useCase.Execute(sedCode, sedVersion);
        return Results.Ok();
    });

app.MapPut("/api/sed",
    (HttpRequest request) => {
        var package = request.Form.Files.Single().OpenReadStream();        
        var useCase = new AddSedMetadata();
        useCase.Execute(package);
        return Results.Ok();
    });

app.MapPut("/api/labels",
    (HttpRequest request) => {
        var package = request.Form.Files.Single().OpenReadStream();        
        var useCase = new AddSedLabels();
        useCase.Execute(package);
        return Results.Ok();
    });

app.Run();

public record SetSedStatusRequest(string status) {}