using System;
namespace IIS.Model
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Miles { get; set; }
        public UserType UserType { get; set; }
    }
}
