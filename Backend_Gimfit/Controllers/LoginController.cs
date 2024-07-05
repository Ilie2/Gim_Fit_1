using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend_Gimfit.Models;
using Backend_Gimfit.Data;

namespace Backend_Gimfit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private readonly DataContext _context;

        public LoginController(IConfiguration config, DataContext context)
        {
            _config = config;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public IResult Login([FromBody] Backend_Gimfit.Models.LoginRequest loginRequest)
        {
            var user = Authenticate(loginRequest);

            if (user != null)
            {
                var token = GenerateJwtToken(user);
                return Results.Ok(token);
            }
            return Results.Unauthorized();
        }

        private object Authenticate(Backend_Gimfit.Models.LoginRequest loginRequest)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Email == loginRequest.Email && c.Password == loginRequest.Password);
            if (client != null)
            {
                return client;
            }

            var trainer = _context.Trainers.SingleOrDefault(t => t.Email == loginRequest.Email && t.Password == loginRequest.Password);
            if (trainer != null)
            {
                return trainer;
            }

            return null;
        }

        private string GenerateJwtToken(object user)
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var base64Key = _config["Jwt:Key"];

            var key = Convert.FromBase64String(base64Key); // Convert base64 key to byte array

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user is Client ? ((Client)user).Email : ((Trainer)user).Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user is Client ? ((Client)user).ID.ToString() : ((Trainer)user).ID.ToString()),
        new Claim(ClaimTypes.Email, user is Client ? ((Client)user).Email : ((Trainer)user).Email),
        new Claim("Role", user is Client ? ((Client)user).Role : ((Trainer)user).Role),
        new Claim("Name", user is Client ? ((Client)user).Name : ((Trainer)user).Name),
        new Claim("LastName", user is Client ? ((Client)user).LastName : ((Trainer)user).LastName)
    };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
