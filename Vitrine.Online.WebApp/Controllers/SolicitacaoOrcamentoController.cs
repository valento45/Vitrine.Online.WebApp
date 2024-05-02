using Microsoft.AspNetCore.Mvc;
using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using Vitrine.Online.WebApp.Application.Interfaces;
using Vitrine.Online.WebApp.Models;

namespace Vitrine.Online.WebApp.Controllers
{
    public class SolicitacaoOrcamentoController : Controller
    {
        private readonly ISolicitacaoOrcamentoApplication _solicitacaoOrcamentoApplication;
        public SolicitacaoOrcamentoController(ISolicitacaoOrcamentoApplication solicitacaoOrcamentoApplication )
        {
            _solicitacaoOrcamentoApplication = solicitacaoOrcamentoApplication;
        }
        [HttpGet]
        public async Task<IActionResult> SolicitacaoOrcamento()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SalvarSolicitacao(SolicitacaoOrcamentoViewModel solicitacaoOrcamentoViewModel)
        {
            if (solicitacaoOrcamentoViewModel.IdSolicitacao > 0)
            {
                SolicitacaoOrcamento solicitacaoOrcamento = new SolicitacaoOrcamento();

                solicitacaoOrcamento.IdSolicitacao = solicitacaoOrcamentoViewModel.IdSolicitacao;
                solicitacaoOrcamento.NomeSolicitacao = solicitacaoOrcamentoViewModel.NomeSolicitacao;
                solicitacaoOrcamento.CelularSolicitacao = solicitacaoOrcamentoViewModel.CelularSolicitacao;
                solicitacaoOrcamento.EmailSolicitacao = solicitacaoOrcamentoViewModel.EmailSolicitacao;
                solicitacaoOrcamento.DescricaoSolicitacao = solicitacaoOrcamentoViewModel.DescricaoSolicitacao;
                solicitacaoOrcamento.EnderecoSolicitacao = solicitacaoOrcamentoViewModel.EnderecoSolicitacao;
                solicitacaoOrcamento.DataSolicitacao = solicitacaoOrcamentoViewModel.DataSolicitacao;

                await _solicitacaoOrcamentoApplication.AtualizarSolicitacao(solicitacaoOrcamento);
            }

            else
            {
                await _solicitacaoOrcamentoApplication.InserirSolicitacao(solicitacaoOrcamentoViewModel);
            }

            MessageViewModel message = new MessageViewModel("Request Added Successfully!",
           "We'll be in touch soon, thank you.");
            return View("SucessoMessage", message);


        }
        [HttpGet]
        public async Task<IActionResult>SolicitarOrcamentoAdm()
        {

            var solicitacaoOrcamentoLista_ = new SolicitacaoOrcamentoLista();

            solicitacaoOrcamentoLista_.ListaSolicitacoes = await _solicitacaoOrcamentoApplication.ObterTodosOrcamento(new SolicitacaoOrcamento());



            return View(solicitacaoOrcamentoLista_);
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirAnexo(long IdSolicitacao)
        {
         

            var result = await _solicitacaoOrcamentoApplication.ExcluirAnexo(IdSolicitacao);

            return RedirectToAction(nameof(SolicitarOrcamentoAdm));
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirSolicitacao(long id)
        {
            

            var result = await _solicitacaoOrcamentoApplication.ExcluirSolicitacao(id);

            return RedirectToAction(nameof(SolicitarOrcamentoAdm));
        }


        [HttpGet]
        public async Task<IActionResult> VerSolicitacao(long id)
        {

            var solicitacaoOrcamento = await _solicitacaoOrcamentoApplication.GetById(id);
            return View(solicitacaoOrcamento);
        }
    }
}
