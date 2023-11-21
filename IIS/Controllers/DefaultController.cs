using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using IIS.Model;
using IIS.Repository;

namespace IIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private IConfiguration configuration;

        public DefaultController(IConfiguration config)
        {
            configuration = config;
        }

        protected User GetCurrentUser()
        {
            string email = HttpContext.User.Claims.FirstOrDefault(u => u.Type == "Email")?.Value;

            User user = null;

            try
            {
                using (var unitOfWork = new UnitOfWork(new IISContext()))
                {
                    user = unitOfWork.Users.GetUserWithEmail(email);


                    unitOfWork.Complete();

                    return user;
                }
            }
            catch (Exception e)
            {
                
            }

            return user;
        }
    }
}
