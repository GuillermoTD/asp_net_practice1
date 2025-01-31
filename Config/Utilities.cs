using System.Security.Cryptography;
using System.Text;
using ASP.NET_Practice.DTO;
using ASP.NET_Practice.Models;

namespace ASP.NET_Practice.Utilities
{
    public static class Tools
    {
        public static BookDTO? ConvertBookDTO(this Book book)
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

        public static UserApiDTO? ConvertUserDTO(this UserModel user)
        {
            if (user != null)
            {
                return new UserApiDTO
                {
                    User = user.User,
                    Token = user.Token
                };
            }
            return null;
        }


        //se encripta la contraseña pasada por parametro
        public static string EncryptPassword(string password)
        {
            using var sha256 = SHA256.Create();
            //se crea un arreglo de bytes a partir del string de la contraseña
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            //Dichos bytes son convertidos a string  y dicho string representa la contraseña que se almacena en base de datos    
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }


        //Se desencripta la contraseña que se pasa por parametro
        public static bool DecryptPassword(string plainpassword, string hashedPassword)
        {
            using var sha256 = SHA256.Create();
            //se crea un arreglo de bytes a partir del string de la contraseña
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainpassword));
            //Dichos bytes son convertidos a string 
            string hashedInput = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashedInput == hashedPassword;
        }
    }
}