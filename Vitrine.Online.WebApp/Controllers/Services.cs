using Microsoft.AspNetCore.Mvc;

namespace Vitrine.Online.WebApp.Controllers
{
    public class Services : Controller
    {
        public Services() { }

        public async Task<IActionResult> VerServicos()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> IncluirTrabalho()
        {

            return View();
        }
    }
}
