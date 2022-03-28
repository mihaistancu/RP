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

app.MapGet("/sed-manifest", () =>
{
    var useCase = new GetSedManifest();
    return useCase.Execute();
})
.WithName("GetSedManifest");

app.Run();

