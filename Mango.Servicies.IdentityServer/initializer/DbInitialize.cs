using Mango.Servicies.IdentityServer.DbContexts;
using Mango.Servicies.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.AccessControl;

namespace Mango.Servicies.IdentityServer.initializer
{
    public class DbInitialize : IDbInitializer
    {
        private readonly ApplicationDbContext _db;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitialize(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.User)).GetAwaiter().GetResult();
            }
            else return;
            ApplicationUser adminUser = new ApplicationUser() { UserName = "adminUser@gmail.com", Email = "adminUser@gmail.com", EmailConfirmed = true, PhoneNumber = "111111111" };

        }
    }
}
