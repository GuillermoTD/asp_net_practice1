using ASP.NET_Practice.Models;
using ASP.NET_Practice.Config;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ASP.NET_Practice.Services
{
    public class ServiceBook : IServiceBook
    {
       internal DbConnection dbconnection = new DbConnection();

       private IMongoCollection<Book> Collection;

       public ServiceBook(){
            Collection = dbconnection.database.GetCollection<Book>("books");
       }

        public async Task InsertBook(Book book){
            await Collection.InsertOneAsync(book);
        }

        public Task UpdateBook(Book book){
            throw new NotImplementedException();
        }

        public Task DeleteBook(Book book){
            throw new NotImplementedException();
        }

        public async Task<List<Book>>GetBooks(){
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Book> GetBookById(string id){
            return await Collection.FindAsync(new BsonDocument{{"_id",new ObjectId(id)}}).Result.FirstAsync();
        }
    }
}
