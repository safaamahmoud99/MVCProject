using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class AccountRepository//: BaseRepository<ApplicationUserIdentity>
    {
        ApplicationUserManager manager;

        public AccountRepository(DbContext db)
        {
            manager = new ApplicationUserManager(db);
        }
        public ApplicationUserIDentity Find(string username, string password)
        {
            ApplicationUserIDentity result = manager.Find(username, password);
            return result;

        }

        public ApplicationUserIDentity FindByName(string username)
        {
            ApplicationUserIDentity result = manager.FindByName(username);
            return result;

        }

        public IdentityResult Register(ApplicationUserIDentity user)
        {
            IdentityResult result = manager.Create(user, user.PasswordHash);
            return result;
        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            IdentityResult result = manager.AddToRole(userid, rolename);
            return result;

        }

        public bool HasRole(string userid, string rolename)
        {
            return manager.IsInRole(userid, rolename);
        }

        public IdentityResult Update(ApplicationUserIDentity user)
        {
            return manager.Update(user);
        }
    }
}
