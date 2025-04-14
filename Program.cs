using JwtApi.Repositories;
using JwtApi.Repositories.Interfaces;
using JwtApi.Services;
using JwtApi.Services.Interfaces;
using Raven.Client.Documents;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var documentStore = new DocumentStore
{
    Urls = new[] { "http://localhost:8080" } ,
    Database = "JwtDataBase"
}.Initialize();

builder.Services.AddSingleton<IDocumentStore>(documentStore);

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
