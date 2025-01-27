using MongoDB.Driver;
using ASP.NET_Practice.Config;
using Swashbuckle.AspNetCore.SwaggerGen;
using ASP.NET_Practice.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Registrar DbConnection como un Singleton
builder.Services.AddSingleton<DbConnection>();


builder.Services.AddScoped<IServiceBook, ServiceBook>();

// Registrar MongoClient como un servicio a partir de DbConnection
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var dbConnection = serviceProvider.GetRequiredService<DbConnection>();
    Console.WriteLine("Connectado a base de datos");
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
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Libros v1"); // Especifica la URL para acceder al archivo swagger.json
        c.RoutePrefix = string.Empty; // Configura Swagger UI para que esté disponible en la raíz del sitio web
    }); // Habilita la interfaz de usuario de Swagger (UI)
}

app.MapControllers();

var dbConnection = app.Services.GetRequiredService<DbConnection>();

app.Run();
