using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitrine.Online.Core.Models.services;
using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using Vitrine.Online.Core.Repositorys.Interfaces;
using Vitrine.Online.Core.Services.Intefaces;

namespace Vitrine.Online.Core.Services
{
    public class ServicoRealizadoService : IServicoRealizadoService
    {
        private readonly IServicoRealizadoRepository _servicoRealizadoRepository;

        public ServicoRealizadoService(IServicoRealizadoRepository servicoRealizadoService)
        {
            _servicoRealizadoRepository = servicoRealizadoService;
        }

        public async Task<bool> InserirServicoRealizado(ServicosRealizado servicosRealizado)
        {
          return await _servicoRealizadoRepository.InserirServicoRealizado(servicosRealizado);
        }

        public async Task<bool> AtualizarServicoRealizado(ServicosRealizado servicosRealizado)
        {
            return await _servicoRealizadoRepository.AtualizarServicoRealizado(servicosRealizado);
        }

        public async Task<bool> ExcluirAnexo(long id)
        {
           return await _servicoRealizadoRepository.ExcluirAnexo(id);
        }

        public async Task<bool> ExcluirServicoRealizado(long id)
        {
            return await _servicoRealizadoRepository.ExcluirServicoRealizado(id);
        }

        public async Task<ServicosRealizado> GetById(long IdServico)
        {
            return await _servicoRealizadoRepository.GetById(IdServico);
        }

        public async Task<bool> IncluirAnexoServicoRealizado(AnexoServicosRealizado anexo)
        {
           return await _servicoRealizadoRepository.IncluirAnexoServicoRealizado(anexo);
        }


        public async Task<IEnumerable<AnexoServicosRealizado>> ObterAnexos(long IdServico)
        {
            return await _servicoRealizadoRepository.ObterAnexos(IdServico);
        }

        public async Task<IEnumerable<ServicosRealizado>> ObterTodosServicosRealizado()
        {
            return await _servicoRealizadoRepository.ObterTodosServicosRealizado();
        }
    }
}
