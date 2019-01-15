using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MNMVehicleMVC.Data;
using MNMVehicleMVC.Model;

namespace MNMVehicleMVC.Controllers
{
    public class TokenController : Controller
    {
        private readonly postgresContext _context;

        public TokenController(postgresContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public IActionResult Post([FromBody]User request)
        {
            if (ModelState.IsValid)
            {
                var user = _context.User.Where(p=>p.Name == request.Name && p.Password == request.Password).FirstOrDefault();
                if (user == null)
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, request.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

                var token = new JwtSecurityToken
                (
                    issuer: "",//_configuration["Issuer"], //appsettings.json içerisinde bulunan issuer değeri
                    audience: "",// _configuration["Audience"],//appsettings.json içerisinde bulunan audince değeri
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(30), // 30 gün geçerli olacak
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("")),//_configuration["SigningKey"] appsettings.json içerisinde bulunan signingkey değeri
                            SecurityAlgorithms.HmacSha256)
                );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest();
        }
    }
}