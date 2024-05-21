using Vitrine.Online.Core.Models.services;
using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using Vitrine.Online.Core.Services;
using Vitrine.Online.Core.Services.Intefaces;
using Vitrine.Online.WebApp.Application.Interfaces;
using Vitrine.Online.WebApp.Models;

namespace Vitrine.Online.WebApp.Application
{
    public class ServicoRealizadoApplication : IServicoRealizadoApplication
    {
        private readonly IServicoRealizadoService _servicoRealizadoService;

        public ServicoRealizadoApplication(IServicoRealizadoService servicoRealizadoService)
        {
            _servicoRealizadoService = servicoRealizadoService;
        }
        public async Task<bool> InserirServicoRealizado(ServicoRealizadoViewModel servicoRealizadoViewModel)
        {
            var obj = new ServicosRealizado()
            {
                IdServico = servicoRealizadoViewModel.IdServico,
                IdCategoria = servicoRealizadoViewModel.IdCategoria,
                DescricaoServico = servicoRealizadoViewModel.DescricaoServico,
                DataServico = servicoRealizadoViewModel.DataServico,
                ResumoServico = servicoRealizadoViewModel.ResumoServico,
                EnderecoServico = servicoRealizadoViewModel.EnderecoServico,
            };
            if(await _servicoRealizadoService.InserirServicoRealizado(obj))
            {
                await this.IncluirAnexoServicoRealizado(servicoRealizadoViewModel.Anexos, obj.IdServico);
                return true;
            }
            return false;
        }

        public async Task<bool> AtualizarServicoRealizado(ServicoRealizadoViewModel servicoRealizadoViewModel)
        {
            ServicosRealizado servicosRealizado = new ServicosRealizado();

            servicosRealizado.IdServico = servicosRealizado.IdServico;
            servicosRealizado.DescricaoServico = servicosRealizado.DescricaoServico;
            servicosRealizado.DataServico = servicosRealizado.DataServico;
            servicosRealizado.ResumoServico = servicosRealizado.ResumoServico;
            servicosRealizado.EnderecoServico = servicosRealizado.EnderecoServico;

            if (await _servicoRealizadoService.AtualizarServicoRealizado(servicosRealizado))
            {

                if (servicoRealizadoViewModel.Anexos?.Any() ?? false)
                {
                    await this.ExcluirAnexo(servicoRealizadoViewModel.IdServico);
                    await this.IncluirAnexoServicoRealizado(servicoRealizadoViewModel.Anexos, servicoRealizadoViewModel.IdServico);
                }

                return true;
            }
            return false;
        }

        public async Task<bool> ExcluirAnexo(long id)
        {
            return await _servicoRealizadoService.ExcluirAnexo(id);
        }

        public async Task<bool> ExcluirServicoRealizado(long id)
        {
            await ExcluirAnexo(id);
            return await _servicoRealizadoService.ExcluirServicoRealizado(id);
        }

        public async Task<ServicosRealizado> GetById(long IdServico)
        {
            var servicosRealizado = await _servicoRealizadoService.GetById(IdServico);

            if (servicosRealizado != null)
            {
                var anexos = await _servicoRealizadoService.ObterAnexos(IdServico);
                servicosRealizado.Imagens = anexos.ToList();
            }

            return servicosRealizado;
        }

        public async Task IncluirAnexoServicoRealizado(List<IFormFile> anexos, long IdServico)
        {
            if (anexos == null)
                return;

            ICollection<AnexoServicosRealizado> anexoServicosRealizados = new List<AnexoServicosRealizado>();

            foreach (IFormFile anex in anexos)
            {
                AnexoServicosRealizado obj = new AnexoServicosRealizado(IdServico);
                var extension = anex.FileName.Substring(anex.FileName.IndexOf('.'));


                using (MemoryStream ms = new MemoryStream())
                {
                    await anex.CopyToAsync(ms);
                    obj.InformarExtensao(extension);
                    obj.InformarAnexoBase64(Convert.ToBase64String(ms.ToArray()));

                    anexoServicosRealizados.Add(obj);
                }


                await _servicoRealizadoService.IncluirAnexoServicoRealizado(obj);
            }
        }

        public async Task<IEnumerable<ServicosRealizado>> ObterTodosServicosRealizado( )
        {
            return await _servicoRealizadoService.ObterTodosServicosRealizado();
        }

        public async Task<IEnumerable<AnexoServicosRealizado>> ObterAnexos(long IdServico)
        {
            return await _servicoRealizadoService.ObterAnexos(IdServico);
        }
    }

        
}
