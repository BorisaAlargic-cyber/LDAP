using System;
using IIS.Model;

namespace IIS.Core
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetUserWithEmail(string email);

        public User GetUserWithEmailAndPassword(string email, string password);
    }
}
