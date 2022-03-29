using RP.Api;
using RP.Services.Dependencies;
using RP.Repositories;

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

app.AddRoutes();

Context.Seds = new SedRepository();
Context.Labels = new LabelRepository();

app.Run();