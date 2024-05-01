using Microsoft.AspNetCore.Mvc;
using Vitrine.Online.WebApp.Application.Interfaces;
using Vitrine.Online.WebApp.Models.Categoria;
using Vitrine.Online.WebApp.Models.Categorias;

namespace Vitrine.Online.WebApp.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaApplication _categoriaApplication;

        public CategoriaController(ICategoriaApplication categoriaApplication)
        {
            _categoriaApplication = categoriaApplication;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = new ListaCategoriasViewModel();

            result.Categorias = await _categoriaApplication.GetAll();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> NovaCategoria()
        {
            return View("CadastroCategoria");
        }

        [HttpPost]
        public async Task<IActionResult> SalvarCategoria(CategoriaViewModel categoriaViewModel)
        {
            if (categoriaViewModel == null)
                return Json(new Exception("Impossível excluir uma categoria nula!"));

            var sucesso = false;
            if (categoriaViewModel.IdCategoria > 0)
                sucesso = await _categoriaApplication.Atualizar(categoriaViewModel);
            else
                sucesso = await _categoriaApplication.Inserir(categoriaViewModel);


            if (sucesso)
                return View("SucessoMessage");
            else
                return View("ErrorMessage");            

        }
    }
}
