using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public class AuthenticationRequestBody
        {
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class User
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }


            public User(string userName, string firstName, string lastName)
            {
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
            }
        }


        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            var user = ValidateUserCredentials(authenticationRequestBody.UserName,
                authenticationRequestBody.FirstName,authenticationRequestBody.LastName);

            if (user == null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"])
                );
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256
                );
            var claimsForToken = new List<Claim>();
            
            claimsForToken.Add(new Claim(ClaimTypes.Name, user.FirstName.ToString()));

            var jwtSecurityToke = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.Now,
                DateTime.Now.AddHours(1),
                signingCredentials
                );

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToke);
            return Ok(tokenToReturn);
        }

        private User ValidateUserCredentials(string userName, string firstName, string lastName)
        {
            return new User(userName, firstName, lastName);
        }

    }
}