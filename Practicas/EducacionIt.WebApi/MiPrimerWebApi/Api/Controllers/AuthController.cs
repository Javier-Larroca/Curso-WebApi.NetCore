using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MiPrimerWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string? _secret;

        public AuthController(IConfiguration configuration) 
        {
            _secret = configuration["Jwt_Secret"] ?? throw new ArgumentException();
        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] UserLogin user)
        { 
            var loggerUser = await AuthenticateUser(user);
            if (loggerUser is null)
            {
                return Unauthorized();
            }
            var token = GenerateJWT(loggerUser);
            return Ok(token);
        }

        private string GenerateJWT(UserModel userModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                "JavierIssuer",
                "JavierAudience",
                null,
                expires : DateTime.Now.AddMinutes(5),
                signingCredentials: credential
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Task<UserModel?> AuthenticateUser(UserLogin userLogin)
        {
            if (userLogin.Username.Equals("Javier", StringComparison.InvariantCultureIgnoreCase)
                && userLogin.Password.Equals("1234"))
            {
                return Task.FromResult(new UserModel(userLogin.Username, "javier-larroca@hotmail.com"));
            }

            return Task.FromResult<UserModel?>(null);
        }

        public record UserLogin(string Username, string Password);

        public record UserModel(string Username, string Email);
    }
}
