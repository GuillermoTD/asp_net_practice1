using Microsoft.AspNetCore.Mvc;
using ASP.NET_Practice.DTO;
using ASP.NET_Practice.Services;
using Microsoft.AspNetCore.Authorization;
using ASP.NET_Practice.Models;
using ASP.NET_Practice.Utilities;
using ZstdSharp.Unsafe;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ASP.NET_Practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        private readonly IUserService _userservice;

        //La interfaz de configuracion permite acceder a configuraciones del archivo appsettings.json
        private readonly IConfiguration _configuration;

        //Contructor
        public LoginController(IUserService service, IConfiguration configuration)
        {
            this._userservice = service;
            this._configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserApiDTO?>> Login(LoginDTO loginuser)
        {
            UserModel User;
            User = await UserAuthenticationAsync(loginuser);

            if (User == null)
            {
                throw new Exception("invalid credentials");
            }
            else
            {
                User = GenerateTokenJWT(User);
            }

            return User.ConvertUserDTO();
        }

        private UserModel GenerateTokenJWT(UserModel userinfo)
        {
            //Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var _header = new JwtHeader(_signingCredentials);
            //Claims
            var _claims = new[]{
                new Claim("user",userinfo.User),
                new Claim("email",userinfo.Email),
            };

            //Payload
            var _payload = new JwtPayload(
                issuer:_configuration["JWT:Issuer"], //Quien esta enviando el token
                audience:_configuration["JWT:Audience"], //Quien recibirá el token
                claims:_claims, //La informacion encriptada
                notBefore:DateTime.UtcNow,// Si existe un claim anterior este lo reemplaza
                expires:DateTime.UtcNow.AddMinutes(20)// tiempo de expiracion del token
            );

            //Token
            var _token = new JwtSecurityToken(
                _header,
                _payload
            );

            userinfo.Token = new JwtSecurityTokenHandler().WriteToken(_token);

            return userinfo;
        }

        private async Task<UserModel> UserAuthenticationAsync(LoginDTO user)
        {
            UserModel User = await _userservice.GetUser(user);

            // using Utilities.EncryptPassword(user.Password);

            if (Tools.DecryptPassword(user.Password, user.Password))
            {
                throw new Exception("Los datos de login son incorrectos");
            }

            return User;
        }
    }

}