using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Town.Helpers;
using Town.Models;

namespace Town.Areas.manage.Controllers
{
    [Area("manage")]
    public class IconSectionController : Controller
    {
        private readonly TownContext _townContext;

        public IconSectionController(TownContext townContext)
        {
            this._townContext = townContext;
        }
        public IActionResult Index(int page=1)
        {
            if (!ModelState.IsValid) return View();

            var query = _townContext.IconSections.AsQueryable();
            var paginatedTeams = PaginatedList<IconSection>.Create(query, 2, page);
            return View(paginatedTeams);
        }

        [HttpGet]
        public IActionResult Create() { return View(); }

         [HttpPost]
        public IActionResult Create(IconSection iconSection) 
        {
            if (!ModelState.IsValid) return View();

            _townContext.IconSections.Add(iconSection);
            _townContext.SaveChanges();

            return RedirectToAction(nameof(Index)); 
        }

         [HttpGet]
        public IActionResult Update(int id)
        {
            IconSection iconSec = _townContext.IconSections.Find(id);
            if(iconSec == null) return NotFound();


            return View(iconSec);
        }

         [HttpPost]
        public IActionResult Update(IconSection iconSection) 
        {

            IconSection ExisticonSec = _townContext.IconSections.Find(iconSection.Id);
            if (ExisticonSec == null) return NotFound();


            ExisticonSec.Title = iconSection.Title;
            ExisticonSec.Desc = iconSection.Desc;
            ExisticonSec.Icon = iconSection.Icon;

            if (!ModelState.IsValid) return View();
            _townContext.SaveChanges();

            return RedirectToAction(nameof(Index)); 
        }


        public IActionResult Delete(int id)
        {
            _townContext.IconSections.Remove(_townContext.IconSections.Find(id));
            _townContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }





    }
}
