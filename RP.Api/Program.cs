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
    return useCase.Execute();
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

app.Run();
