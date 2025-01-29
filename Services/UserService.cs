using ASP.NET_Practice.Models;
using ASP.NET_Practice.Config;
using MongoDB.Driver;
using MongoDB.Bson;
using ASP.NET_Practice.DTO;
using System.Windows.Markup;

namespace ASP.NET_Practice.Services
{
    public class UserService : IUserService
    {
        private DbConnection dbconnection = new DbConnection();
        private readonly IMongoCollection<UserModel> Collection;

        private ILogger<UserService> log;

        //Constructor
        public UserService(ILogger<UserService> log)
        {
            Collection = dbconnection.database.GetCollection<UserModel>("users");
            this.log = log;
        }

        public Task<UserModel>GetUser(LoginApiDTO login){
            try
            {
                var filter = Builders<UserModel>.Filter.Eq(u => u.User, login.User);
            }
            catch (System.Exception error)
            {
                
                log.LogError("Error:" + error.ToString());
                throw new Exception("Se produjo un error obteniendo el usuario" + error.Message);
            }
        }
    }
}