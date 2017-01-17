using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Repository.Interfaces;
using Repository.POCO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        DBContext db;

        public UserRepository(DBContext db)
        {
            this.db = db;
        }
        public bool UserIsInRole(string userName, string roleName)
        {
            using (var db = new DBContext())
            {
                var role = (from r in db.Roles where r.Name.Contains(roleName) select r).FirstOrDefault();

                var users = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();

                if (users.Find(x => x.UserName == userName) != null)
                {
                    return true;
                }
                return false;
            }
        }
        public OperationResult CreateUser(string userName, string password, IAuthenticationManager authManager)
        {
            var userStore = new UserStore<IdentityUser>(db);
            var userManager = new UserManager<IdentityUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var user = new IdentityUser() { UserName = userName };

            IdentityResult result = userManager.Create(user, password);

            if (result.Succeeded)
            { 
                Task<IdentityUser> _user = userStore.FindByNameAsync(user.UserName);

                IdentityRole adminRole = roleManager.FindByName("user");
                string userId = _user.Result.Id;
                userManager.AddToRole(userId, adminRole.Name);

                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                return new OperationResult { Succeded = true };
            }
            return new OperationResult { Succeded = false, Message = "Возникли некоторые ошибки. Попробуйте позже." };
        }
        public OperationResult LoginUser(string userName, string password, IAuthenticationManager authManager)
        {
            var userStore = new UserStore<IdentityUser>(db);

            var userManager = new UserManager<IdentityUser>(userStore);

            var user = userManager.Find(userName, password);

            if (user != null)
            {
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                return new OperationResult { Succeded = true };
            }

            return new OperationResult { Succeded = false, Message = "Пользователя с таким именем или паролем нет." };
        }



    }
}
