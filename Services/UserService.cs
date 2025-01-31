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

        public string Token { get; internal set; }
        public string User { get; internal set; }

        //Constructor
        public UserService(ILogger<UserService> log)
        {
            Collection = dbconnection.database.GetCollection<UserModel>("userapi");
            this.log = log;
        }

        public async Task<UserModel> GetUser(LoginDTO login)
        {
            try
            {
                var filter = Builders<UserModel>.Filter.Eq(u => u.User, login.User);
                    // & Builders<UserModel>.Filter.Eq(u => u.Password, login.Password);

                //Aqui hacemos uso de la definicion filter y traemos el primer elemento que haga match
                return await Collection.FindAsync(filter).Result.FirstAsync();
            }
            catch (System.Exception error)
            {
                // log.LogError("Error:" + error.ToString());
                throw new Exception("Se produjo un error obteniendo el usuario" + "\n" + error.Message);
            }
        }
    }
}