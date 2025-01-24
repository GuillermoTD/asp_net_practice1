using MongoDB.Driver;
using ASP.NET_Practice.Config; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Registrar DbConnection como un Singleton
builder.Services.AddSingleton<DbConnection>();

// Registrar MongoClient como un servicio a partir de DbConnection
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var dbConnection = serviceProvider.GetRequiredService<DbConnection>();
    return dbConnection.client; // Usamooos el cliente de MongoDB de la instancia de DbConnection
});


var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

// Mapear todos los controladores
app.MapControllers();

var dbConnection = app.Services.GetRequiredService<DbConnection>();

app.Run();
