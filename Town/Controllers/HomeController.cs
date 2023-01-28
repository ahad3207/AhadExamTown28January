using Microsoft.AspNetCore.Mvc;
using Town.HomeViewModel;
using Town.Models;

namespace Town.Controllers
{
    public class HomeController : Controller
    {
        private readonly TownContext _townContext;

        public HomeController(TownContext townContext)
        {
            this._townContext = townContext;
        }
        public IActionResult Index()
        {
         
            List<IconSection> iconSections=_townContext.IconSections.ToList();
            return View(iconSections);
        }

    }
}