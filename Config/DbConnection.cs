using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace ASP.NET_Practice.Config
{
    class DbConnection
    {
        public MongoClient client;
        public IMongoDatabase database;

        public DbConnection()
        {
            try
            {
                client = new MongoClient("mongodb+srv://test01:qwerty123123@cluster0.pai7l.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
                database = client.GetDatabase("Books");
                PingDatabase();
            }
            catch (System.Exception ex)
            {

                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }

        }

        // Método para hacer un ping a MongoDB y verificar la conexión
        public void PingDatabase()
        {
            try
            {
                // Ejecutamos un comando de ping a la base de datos 'admin'
                var command = new BsonDocument("ping", 1);
                var result = database.RunCommand<BsonDocument>(command);

                // Si no lanza excepción, significa que la conexión es exitosa
                Console.WriteLine("Conexión exitosa a la base de datos.");
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, la conexión ha fallado
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }

    }
}