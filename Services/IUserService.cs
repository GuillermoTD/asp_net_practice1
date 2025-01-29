using ASP.NET_Practice.DTO;
using ASP.NET_Practice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASP.NET_Practice.Services
{
    public interface IUserService{
       Task<UserModel>GetUser(LoginApiDTO login);
    }

}