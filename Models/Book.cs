using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASP.NET_Practice.Models
{
    public class Book
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public required string Autor { get; set; }
        public required string Titulo { get; set; }
        public required string NumPaginas { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}