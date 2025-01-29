using ASP.NET_Practice.DTO;
using ASP.NET_Practice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASP.NET_Practice.Services
{
    public interface IBookService{
        Task InsertBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Book book);
        Task<IEnumerable<Book>> GetBooks();
        Task<Book>GetBookById(string id);
        Task InsertBook(BookDTO book);
    }

}