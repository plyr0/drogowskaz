using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class DbHelper
    {
        public const string ROLE_ADMINISTRATOR = "Administrator";
        public const string ROLE_USER = "User";

        public static void Seed(ApplicationDbContext context)
        {
            SeedIdentity(context);
        }

        static void SeedIdentity(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(ROLE_ADMINISTRATOR))
            {
                var roleresult = roleManager.Create(new IdentityRole(ROLE_ADMINISTRATOR));
            }
            if (!roleManager.RoleExists(ROLE_USER))
            {
                var roleresult = roleManager.Create(new IdentityRole(ROLE_USER));
            }
            
            string userName = "a@a.a";
            string password = "Aa123$";
            ApplicationUser user = userManager.FindByName(userName);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };
                IdentityResult userResult = userManager.Create(user, password);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, ROLE_ADMINISTRATOR);
                }
            }
        }
    }
}