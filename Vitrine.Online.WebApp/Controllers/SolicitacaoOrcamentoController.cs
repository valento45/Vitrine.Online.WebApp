using Microsoft.AspNetCore.Mvc;

namespace Vitrine.Online.WebApp.Controllers
{
    public class SolicitacaoOrcamentoController : Controller
    {

        public SolicitacaoOrcamentoController()
        {

        }
        [HttpGet]
        public async Task<IActionResult> SolicitacaoOrcamento()
        {
            return View();
        }
    }
}
