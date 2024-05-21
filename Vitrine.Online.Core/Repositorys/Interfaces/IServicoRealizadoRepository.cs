using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitrine.Online.Core.Models.services;
using Vitrine.Online.Core.Models.SolicitacaoOrcamento;

namespace Vitrine.Online.Core.Repositorys.Interfaces
{
    public interface IServicoRealizadoRepository
    {
        Task<bool> InserirServicoRealizado(ServicosRealizado servicosRealizado);
        Task<bool> AtualizarServicoRealizado(ServicosRealizado servicosRealizado);
        Task<bool> ExcluirAnexo(long id);
        Task<bool> ExcluirServicoRealizado(long id);
        Task<bool> IncluirAnexoServicoRealizado(AnexoServicosRealizado anexo);

        Task<IEnumerable<ServicosRealizado>> ObterTodosServicosRealizado();
        Task<ServicosRealizado> GetById(long IdServico);
        Task<IEnumerable<AnexoServicosRealizado>> ObterAnexos(long IdServico);

    }
}
