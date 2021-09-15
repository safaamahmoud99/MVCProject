using BL.Bases;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class AccountAppService : AppServiceBase
    {
        //Login
        public ApplicationUserIDentity Find(string name, string password)
        {
            if (name == string.Empty || password == string.Empty ||
                name == null || password == null)
                throw new ArgumentException("One of the arguments are empity or null");
            return TheUnitOfWork.Account.Find(name, password);
        }
        public ApplicationUserIDentity FindByName(string name)
        {
            if(name == string.Empty || name == null)
                throw new ArgumentException("The name is empity or null");
            return TheUnitOfWork.Account.FindByName(name);
        }
        public IdentityResult Register(RegisterViewodel user)
        {
            if (user == null)
                throw new ArgumentNullException();

            if (user.UserName == string.Empty || user.Email == string.Empty ||
               user.PasswordHash == string.Empty || user.ConfirmPassword == string.Empty ||
               user.Address == string.Empty)
                throw new ArgumentException("One of the arguments are empity");

            if (user.UserName == null || user.Email == null ||
               user.PasswordHash == null || user.ConfirmPassword == null ||
               user.Address == null)
                throw new ArgumentException("One of the arguments are null");

            if (user.PasswordHash != user.ConfirmPassword)
                throw new InvalidOperationException("Password and confirm password must be the same");

            ApplicationUserIDentity identityUser = 
                Mapper.Map<RegisterViewodel, ApplicationUserIDentity>(user);
            return TheUnitOfWork.Account.Register(identityUser);

        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            if (userid == string.Empty || userid == null)
                throw new ArgumentException("userid is empity or null");
            if (rolename == string.Empty || rolename == null)
                throw new ArgumentException("rolename is empity or null");

            return TheUnitOfWork.Account.AssignToRole(userid, rolename);


        }
        public bool HasRole(string userid, string rolename)
        {
            if (userid == string.Empty || userid == null)
                throw new ArgumentException("userid is empity or null");
            if (rolename == string.Empty || rolename == null)
                throw new ArgumentException("rolename is empity or null");

            return TheUnitOfWork.Account.HasRole(userid, rolename);
        }
        public IdentityResult Update(ApplicationUserIDentity user)
        {
            if (user == null)
                throw new ArgumentNullException();

            return TheUnitOfWork.Account.Update(user);
        }
    }
}
