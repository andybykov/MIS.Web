using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        [AllowAnonymous] 
        [HttpPost]
        public ActionResult<string> GetToken(string login)
        {
            var claims = CreateClaims(login);

            var token = new JwtSecurityToken(
                issuer: "Issuer", //	Кто выдал токен 
                notBefore: DateTime.Now,
                claims: claims.Claims,
                expires: DateTime.Now.AddMinutes(120),
                audience: "ForMyApp",  // Кому выдан токен
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysupersecretkey_32bytes_long!!!!!")), SecurityAlgorithms.HmacSha256)
                );

            var result = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(result);
        }

        private ClaimsIdentity CreateClaims(string login)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin"),
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim("id", "100")
            };

            return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
