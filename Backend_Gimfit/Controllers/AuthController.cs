using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend_Gimfit.Data;
using Backend_Gimfit.DTO; // Assumed namespace for DTOs
using Backend_Gimfit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend_Gimfit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("client/login")]
        public async Task<IActionResult> ClientLogin(LoginRequest loginRequest)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Email == loginRequest.Email && c.Password == loginRequest.Password);

            if (client == null)
                return Unauthorized();

            var token = GenerateJwtToken(client);
            return Ok(new { Token = token });
        }

        [AllowAnonymous]
        [HttpPost("trainer/login")]
        public async Task<IActionResult> TrainerLogin(LoginRequest loginRequest)
        {
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.Email == loginRequest.Email && t.Password == loginRequest.Password);

            if (trainer == null)
                return Unauthorized();

            var token = GenerateJwtToken(trainer);
            return Ok(new { Token = token });
        }

        [AllowAnonymous]
        [HttpPost("client/register")]
        public async Task<IActionResult> ClientRegister(ClientDTO registerRequest)
        {
            var existingClient = await _context.Clients.FirstOrDefaultAsync(c => c.Email == registerRequest.Email);

            if (existingClient != null)
                return BadRequest("Email already exists");

            var client = new Client
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                PhoneNumber = registerRequest.PhoneNumber,
                Role = "client", // Set the role for clients
                Name = registerRequest.Name,
                LastName = registerRequest.LastName,
                Subscription = registerRequest.Subscription,
                Description = registerRequest.Description
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            var token = GenerateJwtToken(client);
            return Ok(new { Token = token });
        }

        [AllowAnonymous]
        [HttpPost("trainer/register")]
        public async Task<IActionResult> TrainerRegister(TrainerDTO registerRequest)
        {
            var existingTrainer = await _context.Trainers.FirstOrDefaultAsync(t => t.Email == registerRequest.Email);

            if (existingTrainer != null)
                return BadRequest("Email already exists");

            var trainer = new Trainer
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                PhoneNumber = registerRequest.PhoneNumber,
                Role = "trainer", // Set the role for trainers
                Name = registerRequest.Name,
                LastName = registerRequest.LastName,
                Age = registerRequest.Age,
                Experience = registerRequest.Experience,
                Photo = registerRequest.Photo,
                Description = registerRequest.Description
            };

            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();

            var token = GenerateJwtToken(trainer);
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(object user)
        {
            // Obține cheia dintr-o variabilă de configurare sau din altă sursă securizată
            string secretKey = "supersecretkey123456789012345678901234567890123456789012345678901234567890"; // Exemplu de cheie de 80 de caractere (640 de biți)

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user is Client ? ((Client)user).ID.ToString() : ((Trainer)user).ID.ToString()),
        new Claim(ClaimTypes.Email, user is Client ? ((Client)user).Email : ((Trainer)user).Email),
        new Claim("Role", user is Client ? "client" : "trainer"),
        new Claim("Name", user is Client ? ((Client)user).Name : ((Trainer)user).Name),
        new Claim("LastName", user is Client ? ((Client)user).LastName : ((Trainer)user).LastName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: "yourIssuer",
                audience: "yourAudience",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
