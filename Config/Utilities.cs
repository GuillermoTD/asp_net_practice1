using ASP.NET_Practice.DTO;
using ASP.NET_Practice.Models;


namespace ASP.NET_Practice
{
    public static class Utilities
    {
        public static BookDTO ConvertBookDTO(this Book book)
        {
            if (book != null)
            {
                return new BookDTO
                {
                    IdHex = book.Id.ToString(),
                    Autor = book.Autor,
                    Titulo = book.Titulo,
                    NumPaginas = book.NumPaginas
                };
            }
            return null;
        }
    }
}