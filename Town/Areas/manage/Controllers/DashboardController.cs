using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Town.Models;

namespace Town.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RoleManager<IdentityRole> _roleManager { get; }

        public DashboardController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager )
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CreateAdmin()
        {
            AppUser Admin = new AppUser
            {
                UserName = "Khanim4455",
                FullName = "Khanim Gurbanli"
            };
            var result = await _userManager.CreateAsync(Admin, "Khanim1234");
            return Ok(result);
        }

        public async Task<IActionResult> CreateRole()
        {
            IdentityRole role1 = new IdentityRole("SuperAdmin");
            IdentityRole role2 = new IdentityRole("Admin");
            IdentityRole role3 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);

            return Ok("yarandi");
        }


        public async Task<IActionResult> AddRole()
        {
            AppUser user = await _userManager.FindByNameAsync("Khanim4455");
            await _userManager.AddToRoleAsync(user, "Admin");
            return Ok("Role added");

        }

    }
}
