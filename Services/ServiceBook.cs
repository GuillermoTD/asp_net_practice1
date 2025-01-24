using ASP.NET_Practice.Models;
using ASP.NET_Practice.Config;
using MongoDB.Driver;

namespace ASP.NET_Practice.Services
{
    public class ServiceBook : IServiceBook
    {
       internal DbConnection dbconnection = new DbConnection();

       private IMongoCollection<Book> Collection;

       public ServiceBook(){
            Collection = dbconnection.database.GetCollection<Book>("books");
       }

        public Task InsertBook(Book book){
            throw new NotImplementedException();
        }
        public Task UpdateBook(Book book){
            throw new NotImplementedException();
        }
        public Task DeleteBook(Book book){
            throw new NotImplementedException();
        }
    }
}
