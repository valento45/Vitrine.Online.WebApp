using Microsoft.AspNetCore.Mvc;
using Vitrine.Online.WebApp.Application.Interfaces;

namespace Vitrine.Online.WebApp.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaApplication _categoriaApplication;

        public CategoriaController(ICategoriaApplication categoriaApplication)
        {
            _categoriaApplication = categoriaApplication;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
