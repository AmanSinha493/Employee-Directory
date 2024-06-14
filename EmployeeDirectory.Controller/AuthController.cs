using EmployeeDirectory.DTO;
using EmployeeDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EmployeeDirectory.Controller
{
    [ApiController]
    [Route("/api")]
    public class Authcontroller : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserServices _userServices;
        public Authcontroller(IConfiguration config, IUserServices userServices)
        {
            _config = config;
            _userServices = userServices;
        }


        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            User user = AuthenticateUser(userLogin);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }


        [HttpPost("register")]
        public IActionResult Add([FromBody] DTO.User user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                user.password = HashPassword(user.password);
                _userServices.Add(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            Console.WriteLine(_config["Jwt:Key"]);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user!.user.ToString()!),
                new Claim(ClaimTypes.Role, user!.role.ToString()!),
            };
            var token = new JwtSecurityToken(
             issuer: _config["Jwt:Issuer"],
             audience: _config["Jwt:Audience"],
             claims: claims,
             expires: DateTime.Now.AddDays(1),
             signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        //private User? AuthenticateUser(UserLogin userLogin)
        //{
        //    var currentUser = _userServices.Get().FirstOrDefault(o => o.user.ToLower() == userLogin.user.ToLower() && o.password == HashPassword(userLogin.password));
        //    if (currentUser != null)
        //    {
        //        return currentUser;
        //    }
        //    return null;
        //}
        private User? AuthenticateUser(UserLogin userLogin)
        {
            var hashedPassword = HashPassword(userLogin.password);
            var currentUser = _userServices.Get().FirstOrDefault(o => o.user.ToLower() == userLogin.user.ToLower() && o.password == hashedPassword);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }


        //private string HashPassword(string password)
        //{
        //    var sha = SHA256.Create();
        //    var asBytedArray = Encoding.UTF8.GetBytes(password);
        //    var hashedPassword = sha.ComputeHash(asBytedArray);
        //    return hashedPassword.ToString();
        //}
        private string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                var asBytedArray = Encoding.UTF8.GetBytes(password);
                var hashedPassword = sha.ComputeHash(asBytedArray);
                return Convert.ToBase64String(hashedPassword);
            }
        }

    }
}
