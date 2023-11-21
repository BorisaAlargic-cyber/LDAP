using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using IIS.Model;
using IIS.Repository;
using Novell.Directory.Ldap;

namespace IIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration configuration;

        public TokenController(IConfiguration config)
        {
            configuration = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User data)
        {
            if (data == null || data.Email == null || data.Password == null)
            {
                return BadRequest();
            }
            User user = null;

            try
            {
                using (var unitOfWork = new UnitOfWork(new IISContext()))
                {
                    user = unitOfWork.Users.GetUserWithEmailAndPassword(data.Email,data.Password);
                }

            }
            catch (Exception e)
            {

            }

            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }

            using (var ldapConnection = new LdapConnection())
            {
                try
                {
                    ldapConnection.Connect("localhost", 389);
                    ldapConnection.Bind("cn=admin,dc=xl,dc=com", "password");

                    string filter = $"(&(objectClass=inetOrgPerson)(uid={user.Email}))";
                    var searchResults = ldapConnection.Search(
                        "dc=xl,dc=com", // Base DN for the search
                        LdapConnection.ScopeSub, // Search scope (subtree)
                        filter, // Search filter
                        null, // Attributes to retrieve (null for all attributes)
                        false // Types only (false to retrieve attribute values)
                    );

                    while (searchResults.HasMore())
                    {
                        LdapEntry entry = null;
                        try
                        {
                            entry = searchResults.Next();

                            if (entry.GetAttribute("userPassword") == null || entry.GetAttribute("userPassword").StringValue != data.Password)
                            {
                                return BadRequest("Invalid credentials");
                            }
                        }
                        catch (LdapException e)
                        {
                            Console.WriteLine($"Error reading entry: {e.Message}");
                        }
                    }

                }
                catch (Exception e)
                {

                }
                finally
                {

                }
            }

             
          

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("Email", user.Email)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { tokenString });
        }

    }
}
