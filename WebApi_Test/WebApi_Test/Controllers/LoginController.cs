using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi_Test.Models;

namespace WebApi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IConfiguration _config;

        public LoginController( IConfiguration config)
        {
           
            _config = config;
        }



        [HttpGet]
        public IActionResult Login(string username, String pass)
        {
            Login login = new Login();
            login.Username = username;
            login.password = pass;
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenStr = GenerateToken(user);
                response = Ok(new { token = tokenStr });
            }

            return response;
        }


        private Login AuthenticateUser(Login login)
        {
            Login user = null;
            if (login.Username == "sooraj" && login.password == "12345")
            {
                user = new Login { Username = "Sooraj", password = "12345" };
            }

            return user;
        }



        private string GenerateToken(Login login)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                        claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: credentials);


            //);
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;

        }

    }
}