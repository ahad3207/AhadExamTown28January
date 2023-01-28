using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Town.Areas.manage.AreaViewModel;
using Town.Helpers;
using Town.Models;

namespace Town.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public TownContext _townContext { get; }

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,TownContext townContext)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            _townContext = townContext;
        }


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index(int page=1)
        {

            var query = _townContext.Users.AsQueryable();
            var PaginatdUsers = PaginatedList<AppUser>.Create(query, 2, page);

            //List<AppUser> Users= _townContext.Users.ToList();
            return View(PaginatdUsers);
        }


        [HttpPost]
        public async Task <IActionResult> Login(AdminLoginviewModel adminLoginviewModel)
        {
            if (!ModelState.IsValid) {  return View(); }

            AppUser admin =await _userManager.FindByNameAsync(adminLoginviewModel.UserName);
            if(admin == null)
            {
                ModelState.AddModelError("username", "Password or Username is incorrect");
                return View();
            }

            var result =await _signInManager.PasswordSignInAsync(admin,adminLoginviewModel.Password,false,false);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("Password", "Password or Username is incorrect");
                return View();

            }

            return RedirectToAction("Index", "dashboard");   
        }

    }
}
