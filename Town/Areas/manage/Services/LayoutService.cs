using Microsoft.AspNetCore.Identity;
using Town.Models;

namespace Town.Areas.manage.Services
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserManager<AppUser> _userManager { get; }

        public LayoutService(IHttpContextAccessor httpContextAccessor,UserManager<AppUser> userManager)
        {
            this._httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }


        public async Task<AppUser> GetUser()
        {
            string name = _httpContextAccessor.HttpContext.User.Identity.Name;
            AppUser appUser = await _userManager.FindByNameAsync(name);

            return appUser;
        }

    }
}
