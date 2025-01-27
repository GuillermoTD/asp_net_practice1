using MongoDB.Driver;
using ASP.NET_Practice.Config; 
using Swashbuckle.AspNetCore.SwaggerGen;
using ASP.NET_Practice.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Registrar DbConnection como un Singleton
// builder.Services.AddSingleton<DbConnection>();


builder.Services.AddScoped<IServiceBook, ServiceBook>();

// Registrar MongoClient como un servicio a partir de DbConnection
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var dbConnection = serviceProvider.GetRequiredService<DbConnection>();
    return dbConnection.client; // Usamooos el cliente de MongoDB de la instancia de DbConnection
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

// Mapear todos los controladores

// Configurar el middleware HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita Swagger en modo de desarrollo
    app.UseSwaggerUI(); // Habilita la interfaz de usuario de Swagger (UI)
}

app.MapControllers();

var dbConnection = app.Services.GetRequiredService<DbConnection>();

app.Run();
