using ASP.NET_Practice.Models;
using ASP.NET_Practice.Config;
using MongoDB.Driver;
using MongoDB.Bson;
using ASP.NET_Practice.DTO;

namespace ASP.NET_Practice.Services
{
    public class BookService : IBookService
    {
       internal DbConnection dbconnection = new DbConnection();

       private readonly IMongoCollection<Book> Collection;

       public BookService(){
            Collection = dbconnection.database.GetCollection<Book>("books");
       }

        public async Task InsertBook(Book book){
            await Collection.InsertOneAsync(book);
        }

        public async Task UpdateBook(Book book){
            //Aqui se filtra para buscar y comparar el libro pasado por parametro con los libros almacenados en MongoDB
            var filter = Builders<Book>.Filter.Eq(s=>s.Id, book.Id);
            //Aqui se reemplaza los nuevos valores del libro que ya estaba
            await Collection.ReplaceOneAsync(filter,book);
        }

        public async Task DeleteBook(Book book){
             //Aqui se filtra para buscar y comparar el libro pasado por parametro con los libros almacenados en MongoDB
             var filter = Builders<Book>.Filter.Eq(s=>s.Id, book.Id);
             Console.WriteLine(filter);
             await Collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Book>>GetBooks(){
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Book> GetBookById(string id){
            return await Collection.FindAsync(new BsonDocument{{"_id",new ObjectId(id)}}).Result.FirstAsync();
        }

        public Task InsertBook(BookDTO book)
        {
            throw new NotImplementedException();
        }
    }
}
