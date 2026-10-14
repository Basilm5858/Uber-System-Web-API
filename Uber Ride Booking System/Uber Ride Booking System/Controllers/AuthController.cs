using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Uber_Ride_Booking_System.DTOs;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _unitOfWork.authRepo.GetById(id);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var exiemail = _unitOfWork.authRepo.GetByEmail(dto.Email);
            if (exiemail != null)
            {
                return BadRequest("Email is exist");
            }
            var res = new User
            {
                Email = dto.Email,
                Password = dto.Password,
                Phone = dto.Phone,
                FullName = dto.FullName,
                Role = dto.Role,
            };

            await _unitOfWork.authRepo.Add(res);
            await _unitOfWork.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var exi = await _unitOfWork.authRepo.GetByEmail(dto.Email);
            if (exi == null)
            {
                return BadRequest("invalid email or password");
            }
            if(dto.Password  != dto.Password)
            {
                return BadRequest("invalid email or password");
            }
            var token = GenerateToken(exi);
            return Ok(token);

        }


        private string GenerateToken(User user)
        {
            // payload
            var claims = new List<Claim>
            {

                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Name,user.FullName),
                    new Claim(ClaimTypes.Role,user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creads = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Iss"],
                audience: _configuration["JWT:Aud"],
                signingCredentials: creads,
                claims: claims,
                expires: DateTime.Now.AddDays(1)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
