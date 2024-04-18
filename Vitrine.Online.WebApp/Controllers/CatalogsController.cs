using Microsoft.AspNetCore.Mvc;

namespace Vitrine.Online.WebApp.Controllers
{
    public class CatalogsController : Controller
    {

        public CatalogsController()
        {
                
        }


        public async Task<IActionResult> VerCatalogo()
        {
            return View();
        }
    }
}
