using System;
using IIS.Model;
using IIS.Repository;
using Novell.Directory.Ldap;

namespace IIS.Service
{
    public class UserService
    {
        public UserService()
        {
        }

        public User Registration(User user)
        {
            try
            {


                using (var ldapConnection = new LdapConnection())
                {
                    try
                    {
                        ldapConnection.Connect("localhost", 389);
                        ldapConnection.Bind("cn=admin,dc=xl,dc=com", "password");

                        var dn = $"uid={user.Email},dc=xl,dc=com";

                        LdapAttributeSet attributeSet = new LdapAttributeSet();
                        attributeSet.Add(new LdapAttribute("objectClass", "inetOrgPerson"));
                        attributeSet.Add(new LdapAttribute("cn", user.FirstName + " " + user.LastName));
                        attributeSet.Add(new LdapAttribute("sn", user.LastName));
                        attributeSet.Add(new LdapAttribute("givenName", user.FirstName));
                        attributeSet.Add(new LdapAttribute("mail", user.Email));
                        attributeSet.Add(new LdapAttribute("userPassword", user.Password));

                        LdapEntry entry = new LdapEntry(dn, attributeSet);

                        ldapConnection.Add(entry);
                    }
                    catch (Exception e)
                    {

                    }
                    finally
                    {
                        ldapConnection.Disconnect();
                    }
                 }


                    using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    User dbUser = unitOfWork.Users.GetUserWithEmail(user.Email);

                    if(dbUser  != null)
                    {
                        return null;
                    }

                    dbUser = new User();

                    dbUser.FirstName = user.FirstName;
                    dbUser.LastName = user.LastName;
                    dbUser.Email = user.Email;
                    dbUser.Password = user.Password;
                    dbUser.UserType = UserType.Customer;

                    unitOfWork.Users.Add(dbUser);
                    unitOfWork.Complete();

                    return dbUser;
                }
            }
            catch(Exception ee)
            {
                return null;
            }
        }

        public User EditUser(User user)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    User dbUser = unitOfWork.Users.Get(user.Id);

                    dbUser.FirstName = user.FirstName;
                    dbUser.LastName = user.LastName;
                    dbUser.Email = user.Email;

                    unitOfWork.Users.Update(dbUser);
                    unitOfWork.Complete();

                    return dbUser;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    User user = unitOfWork.Users.Get(id);

                    unitOfWork.Users.Update(user);
                    user.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception ee)
            {

            }
        }


    }
}
