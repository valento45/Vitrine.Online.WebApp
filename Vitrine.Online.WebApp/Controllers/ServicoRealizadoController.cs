using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Vitrine.Online.Core.Models.services;
using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using Vitrine.Online.WebApp.Application;
using Vitrine.Online.WebApp.Application.Interfaces;
using Vitrine.Online.WebApp.Models;
using Vitrine.Online.WebApp.Models.Categorias;

namespace Vitrine.Online.WebApp.Controllers
{
    public class ServicoRealizadoController : Controller
    {
        private readonly IServicoRealizadoApplication _servicoRealizadoApplication;
        private readonly ICategoriaApplication _categoriaApplication;

        public ServicoRealizadoController(IServicoRealizadoApplication servicoRealizadoApplication, ICategoriaApplication categoriaApplication)
        {
            _servicoRealizadoApplication = servicoRealizadoApplication;
            _categoriaApplication = categoriaApplication;
        }

        public async Task<IActionResult> Index()
        {
            ServicosRealizadosLista result = new ServicosRealizadosLista();
            result.ListaServico = await _servicoRealizadoApplication.ObterTodosServicosRealizado();
            return View(result);

        }

        [HttpGet]
        public async Task<IActionResult> EditarServico(long id)
        {
            var result = await _servicoRealizadoApplication.GetById(id);

            var servicoRealizadoViewModel = new ServicoRealizadoViewModel();

            servicoRealizadoViewModel.IdServico = result.IdServico;
            servicoRealizadoViewModel.IdCategoria = result.IdCategoria;
            servicoRealizadoViewModel.DescricaoServico = result.DescricaoServico;
            servicoRealizadoViewModel.DataServico = result.DataServico;
            servicoRealizadoViewModel.ResumoServico = result.ResumoServico;
            servicoRealizadoViewModel.EnderecoServico = result.EnderecoServico;

            servicoRealizadoViewModel.Categorias = await _categoriaApplication.GetAll();


            return View("IncluirTrabalho", servicoRealizadoViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> VerServicos([FromBody] ServicosRealizado servico)
        {

            return View(servico);
        }

        [HttpGet]
        public async Task<IActionResult> NovoTrabalho()
        {

            ServicoRealizadoViewModel servicoRealizadoViewModel = new ServicoRealizadoViewModel();

            servicoRealizadoViewModel.Categorias = await  _categoriaApplication.GetAll();


            return View("IncluirTrabalho", servicoRealizadoViewModel); 
        }    

        [HttpPost]
        public async Task<IActionResult> SalvarServico(ServicoRealizadoViewModel servicoRealizadoViewModel)
        {
            if (servicoRealizadoViewModel.IdServico > 0)
            {
                ServicosRealizado servicoRealizado = new ServicosRealizado();

                servicoRealizado.IdServico = servicoRealizadoViewModel.IdServico;
                servicoRealizado.IdCategoria = servicoRealizadoViewModel.IdCategoria;
                servicoRealizado.DescricaoServico = servicoRealizadoViewModel.DescricaoServico;
                servicoRealizado.DataServico = servicoRealizadoViewModel.DataServico;
                servicoRealizado.ResumoServico = servicoRealizadoViewModel.ResumoServico;
                servicoRealizado.EnderecoServico = servicoRealizadoViewModel.EnderecoServico;

                await _servicoRealizadoApplication.AtualizarServicoRealizado(servicoRealizadoViewModel);
            }
            else
            {
                await _servicoRealizadoApplication.InserirServicoRealizado(servicoRealizadoViewModel);
            }

            MessageViewModel message = new MessageViewModel("Request Added Successfully!",
           "We'll be in touch soon, thank you.");
            return View("SucessoMessage", message);

        }

       
        [HttpGet]
        public async Task<IActionResult> ServicoRealizadoAdm()
        {
            var servicosRealizadoLista_ = new ServicosRealizadosLista();


            servicosRealizadoLista_.ListaServico = await _servicoRealizadoApplication.ObterTodosServicosRealizado();



            return View(servicosRealizadoLista_);
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirAnexo(long id)
        {

            var result = await _servicoRealizadoApplication.ExcluirAnexo(id);

            return RedirectToAction(nameof(ServicoRealizadoAdm));
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirServicoRealizado(long id)
        {

            var result = await _servicoRealizadoApplication.ExcluirServicoRealizado(id);

            return RedirectToAction(nameof(ServicoRealizadoAdm));
        }


       

    }
}
