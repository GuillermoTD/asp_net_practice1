using ASP.NET_Practice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASP.NET_Practice.Services
{
    public interface IServiceBook{
        Task InsertBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Book book);
        Task<List<Book>> GetBooks();
        Task<Book>GetBookById(string id);
    }

}