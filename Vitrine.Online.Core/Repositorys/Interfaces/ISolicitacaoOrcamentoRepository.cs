using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitrine.Online.Core.Models.SolicitacaoOrcamento;

namespace Vitrine.Online.Core.Repositorys.Interfaces
{
    public interface ISolicitacaoOrcamentoRepository
    {
        Task<bool> InserirSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento);
        Task<bool> AtualizarSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento);
        Task<bool> ExcluirAnexo(long IdSolicitacao);
        Task<bool> ExcluirSolicitacao(long IdSolicitacao);
        Task<bool> IncluirAnexoSolicitacao(AnexoSolicitacaoOrcamento anexo);

        Task<IEnumerable<SolicitacaoOrcamento>> ObterTodosOrcamento(SolicitacaoOrcamento solicitacaoOrcamento);
        Task<SolicitacaoOrcamento> GetById(long id);
        Task<IEnumerable<AnexoSolicitacaoOrcamento>> ObterAnexos(long IdSolicitacao);

    }
}
