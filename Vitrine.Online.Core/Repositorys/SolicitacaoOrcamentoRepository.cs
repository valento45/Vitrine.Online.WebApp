using Expert.Gov.Core.Repositorys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using Vitrine.Online.Core.Repositorys.Interfaces;

namespace Vitrine.Online.Core.Repositorys
{
    public class SolicitacaoOrcamentoRepository : RepositoryBase, ISolicitacaoOrcamentoRepository

    {

        public SolicitacaoOrcamentoRepository(IDbConnection dbConnection) : base(dbConnection) 
        {

        }
        public Task<bool> InserirSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento)
        {
           //string query = " insert into SolicitacaoOrcamento_tb " +
               
                     throw new NotImplementedException();
        }

        public Task<bool> AtualizarSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IncluirAnexoSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SolicitacaoOrcamento>> ObterTodosAnexos(long IdSolicitacao)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SolicitacaoOrcamento>> ObterTodosOrcamento(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirAnexo(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            throw new NotImplementedException();
        }

        public Task<SolicitacaoOrcamento> GetById(long id)
        {
            throw new NotImplementedException();
        }

  
    }
}
