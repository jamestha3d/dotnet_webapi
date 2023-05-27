global using AutoMapper;
global using dotnet.Models;
global using dotnet.Services.CharacterService;
global using dotnet.Dtos.Character;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly); //register automapper
//add scoped service for "Unable to resolve service for type"
//addscoped provides new instance of requested service for every request, addSingleton creates single instance used for every request, add transient provides new instance to every controller and service within request
builder.Services.AddScoped<ICharacterService, CharacterService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
