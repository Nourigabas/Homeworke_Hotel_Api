using AutoMapper;
using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.Models.Authentication;
using Homeworke_Hotel_Api.ViewModels.Booking;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Homeworke_Hotel_Api.Controllers
{
        [ApiController]
        [Route("api/[Controller]")]
    public class AccountController : Controller
    {
        private readonly IConfiguration configuration;
        public AccountController(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        //فحص معلومات المستخدم وجلب
        //token
        [HttpPost("Authentication")]
        public ActionResult<string> LoginAccount([FromBody]AuthRequest Request)
        {
            if (Request.Username != configuration["user:username"] || Request.Password != configuration["user:password"])
                return Unauthorized();

            var Claims = new List<Claim>();
            Claims.Add(new Claim(ClaimTypes.GivenName, "Nouri"));
            Claims.Add(new Claim("family_name", "gabas"));
            Claims.Add(new Claim("Working", "Eng"));

            var SecretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:SecretKey"]));
            var SigningCred = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);
            var SecurityToken = new JwtSecurityToken
            (
            configuration["Authentication:Issuer"],
            configuration["Authentication:Audience"],
            Claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(1),
            SigningCred
            );
            var Token = new JwtSecurityTokenHandler().WriteToken(SecurityToken);
            return Ok(Token);
        }
    }
}
