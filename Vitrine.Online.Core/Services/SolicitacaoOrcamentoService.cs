using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using Vitrine.Online.Core.Repositorys.Interfaces;
using Vitrine.Online.Core.Services.Intefaces;

namespace Vitrine.Online.Core.Services
{
    public class SolicitacaoOrcamentoService : ISolicitacaoOrcamentoService
    {
        private readonly ISolicitacaoOrcamentoRepository _solicitacaoOrcamentoRepository;

        public SolicitacaoOrcamentoService(ISolicitacaoOrcamentoRepository solicitacaoOrcamentoRepository)
        {
            _solicitacaoOrcamentoRepository = solicitacaoOrcamentoRepository;
        }
        public async Task<bool> AtualizarSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento)
        {
           return await  _solicitacaoOrcamentoRepository.AtualizarSolicitacao(solicitacaoOrcamento);
        }

        public async Task<bool> ExcluirAnexo(long IdSolicitacao)
        {
            return await _solicitacaoOrcamentoRepository.ExcluirAnexo(IdSolicitacao);
        }

        public async Task<bool> ExcluirSolicitacao(long IdSolicitacao)
        {
            return await _solicitacaoOrcamentoRepository.ExcluirSolicitacao(IdSolicitacao);
        }

        public async Task<SolicitacaoOrcamento> GetById(long id)
        {
            return await _solicitacaoOrcamentoRepository.GetById(id);
        }

        public async Task<bool> IncluirAnexoSolicitacao(AnexoSolicitacaoOrcamento anexo)
        {
            return await _solicitacaoOrcamentoRepository.IncluirAnexoSolicitacao(anexo);
        }

        public async Task<bool> InserirSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            return await _solicitacaoOrcamentoRepository.InserirSolicitacao(solicitacaoOrcamento);
        }

        public async Task<IEnumerable<AnexoSolicitacaoOrcamento>> ObterAnexos(long IdSolicitacao)
        {
            return await _solicitacaoOrcamentoRepository.ObterAnexos(IdSolicitacao);
        }

        public async Task<IEnumerable<SolicitacaoOrcamento>> ObterTodosOrcamento(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            return await _solicitacaoOrcamentoRepository.ObterTodosOrcamento(solicitacaoOrcamento);
        }
    }
}
