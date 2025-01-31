using ASP.NET_Practice.DTO;
using ASP.NET_Practice.Models;
using ASP.NET_Practice.Services;
using ASP.NET_Practice.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ASP.NET_Practice.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SignupController : Controller{
        private readonly IUserService _userservice;
        private readonly IConfiguration _configuration;

         //Contructor
        public SignupController(IUserService service, IConfiguration configuration)
        {
            this._userservice = service;
            this._configuration = configuration;
        }


        // [HttpPost]
        // [AllowAnonymous]
        //  public async Task<ActionResult<UserApiDTO?>> Signup(SignupDTO signupuser)
        // {
        //     UserModel User;
        //     User = await UserAuthenticationAsync(signupuser);

        //     return User.ConvertUserDTO();
        // }

        // public async Task<ActionResult<User>>
    }
}