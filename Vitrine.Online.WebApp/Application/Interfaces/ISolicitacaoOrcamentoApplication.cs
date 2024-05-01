using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using Vitrine.Online.WebApp.Models;

namespace Vitrine.Online.WebApp.Application.Interfaces
{
    public interface ISolicitacaoOrcamentoApplication
    {

        Task<bool> InserirSolicitacao(SolicitacaoOrcamentoViewModel solicitacaoOrcamentoViewModel);
        Task<bool> AtualizarSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento);
        Task<bool> ExcluirAnexo(long IdSolicitacao);
        Task<bool> ExcluirSolicitacao(long IdSolicitacao);
        Task IncluirAnexoSolicitacao(List<IFormFile> anexos, long idSolicitacao);

        Task<IEnumerable<SolicitacaoOrcamento>> ObterTodosOrcamento(SolicitacaoOrcamento solicitacaoOrcamento);
        Task<SolicitacaoOrcamento> GetById(long id);
        Task<IEnumerable<AnexoSolicitacaoOrcamento>> ObterAnexos(long IdSolicitacao);
    }
}
