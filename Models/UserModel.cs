using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASP.NET_Practice.Models
{
    public class UserModel{
        [BsonId]
        public required ObjectId Id{get;set;}

        [BsonElement("idHex")]
        public string IdHex => Id.ToString();

        public required string User {get; set;}

        public string Password {get;set;}
        public string Email {get;set;}

        public string Token {get;set;}
        
       [BsonRepresentation(BsonType.DateTime)]
        public DateTime Registration_Date {get;set;}

         [BsonRepresentation(BsonType.DateTime)]
        public DateTime? Cancelation_Date {get;set;}

    }
}