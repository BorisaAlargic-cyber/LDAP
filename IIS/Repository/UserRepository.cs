using System;
using System.Linq;
using IIS.Core;
using IIS.Model;

namespace IIS.Repository
{
    public class UserRepository : Repository<User> ,IUserRepository
    {
        public UserRepository(IISContext context) : base(context) { }


        public User GetUserWithEmail(string email)
        {
            return IISContext.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetUserWithEmailAndPassword(string email,string password)
        {
            return IISContext.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}
