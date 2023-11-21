using System;
using System.Threading.Tasks;
using IIS.Model;
using IIS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : DefaultController
    {
        UserService service = new UserService();

        public UserController(IConfiguration config) : base(config)
        {
        }

        [HttpPost]
        [Route("/api/users")]
        public async Task<IActionResult> Register(User userData)
        {
            User user = service.Registration(userData);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [Authorize]
        [HttpGet]
        [Route("/api/users/get-current")]
        public async Task<IActionResult> GetCurrent()
        {
            User user = GetCurrentUser();

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/users/edit")]
        public async Task<IActionResult> EditProfile(User userData)
        {
            User user = service.EditUser(userData);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpDelete]
        [Route("/api/users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            service.DeleteUser(id);

            return Ok();
        }
    }
}
