using Vitrine.Online.Core.Models.services;
using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using Vitrine.Online.WebApp.Models;

namespace Vitrine.Online.WebApp.Application.Interfaces
{
    public interface IServicoRealizadoApplication
    {
        Task<bool> InserirServicoRealizado(ServicoRealizadoViewModel servicoRealizadoViewModel);
        Task<bool> AtualizarServicoRealizado(ServicoRealizadoViewModel servicoRealizadoViewModel);
        Task<bool> ExcluirAnexo(long IdServico);
        Task<bool> ExcluirServicoRealizado(long id);
        Task IncluirAnexoServicoRealizado(List<IFormFile> anexos, long IdServico);

        Task<IEnumerable<ServicosRealizado>> ObterTodosServicosRealizado();
        Task<ServicosRealizado> GetById(long IdServico);
        Task<IEnumerable<AnexoServicosRealizado>> ObterAnexos(long IdServico);
    }
}
