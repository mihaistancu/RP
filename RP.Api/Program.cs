using System.Text;

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
})
.WithName("GetSedManifest");

app.MapGet("/api/sed/{sedCode}/{sedVersion}", (string sedCode, string sedVersion) => {
    var useCase = new GetSedMetadata();
    var metadata = useCase.Execute(sedCode, sedVersion);
    return Results.Stream(metadata, @"application\json");
})
.WithName("GetSed");

app.Run();
