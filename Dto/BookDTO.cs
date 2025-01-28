using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using ASP.NET_Practice.Models;

namespace ASP.NET_Practice.DTO
{
    public class BookDTO{

    
    [BsonElement("idHex")]
    public required string IdHex { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public required string Autor { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public required string Titulo { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public required string NumPaginas { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public DateTime FechaPublicacion { get; set; }

    }
}