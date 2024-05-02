using Expert.Gov.Core.Repositorys;
using Npgsql;
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
        public async Task<bool> InserirSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            string query = " insert into solicitacao_orcamento_tb " +
            "(nomeSolicitacao, celularSolicitacao, emailSolicitacao, enderecoSolicitacao, descricaoSolicitacao," +
            " dataSolicitacao)" +
            "values (@nomeSolicitacao, @celularSolicitacao, @emailSolicitacao, @enderecoSolicitacao," +
            " @descricaoSolicitacao, @dataSolicitacao) returning idSolicitacao;";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"nomeSolicitacao", solicitacaoOrcamento.NomeSolicitacao);
            cmd.Parameters.AddWithValue(@"celularSolicitacao", solicitacaoOrcamento.CelularSolicitacao);
            cmd.Parameters.AddWithValue(@"emailSolicitacao", solicitacaoOrcamento.EmailSolicitacao);
            cmd.Parameters.AddWithValue(@"enderecoSolicitacao", solicitacaoOrcamento.EnderecoSolicitacao);
            cmd.Parameters.AddWithValue(@"descricaoSolicitacao", solicitacaoOrcamento.DescricaoSolicitacao);
            cmd.Parameters.AddWithValue(@"dataSolicitacao", solicitacaoOrcamento.DataSolicitacao);

            var result = await base.ExecuteScalarAsync(cmd);

            if (result != null)
            {
                solicitacaoOrcamento.IdSolicitacao = long.Parse(result.ToString());
            }

            return solicitacaoOrcamento.IdSolicitacao > 0;
        }

        public async Task<bool> AtualizarSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            string query = "update solicitaco_orcamento_tb set nomeSolicitacao = @nomeSolicitacao, " +
                 "celularSolicitacao = @celularSolicitacao, emailSolicitacao = @emailSolicitacao," +
                 "enderecoSolicitacao = @enderecoSolicitacao, descricaoSolicitacao = @descricaoSolicitacao," +
                 "descricaoSolicitacao = @dataSolicitacao where idSolicitacao = @idSolicitacao ";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"IdSolicitacao", solicitacaoOrcamento.IdSolicitacao);
            cmd.Parameters.AddWithValue(@"nomeSolicitacao", solicitacaoOrcamento.NomeSolicitacao);
            cmd.Parameters.AddWithValue(@"celularSolicitacao", solicitacaoOrcamento.CelularSolicitacao);
            cmd.Parameters.AddWithValue(@"emailSolicitacao", solicitacaoOrcamento.EmailSolicitacao);
            cmd.Parameters.AddWithValue(@"enderecoSolicitacao", solicitacaoOrcamento.EnderecoSolicitacao);
            cmd.Parameters.AddWithValue(@"descricaoSolicitacao", solicitacaoOrcamento.DescricaoSolicitacao);
            cmd.Parameters.AddWithValue(@"descricaoSolicitacao", solicitacaoOrcamento.DataSolicitacao);

            return await base.ExecuteCommand(cmd);

        }

        public async Task<bool> IncluirAnexoSolicitacao(AnexoSolicitacaoOrcamento anexo )
        {
            string query = "insert into anexo_solicitacao_tb (idSolicitacao, anexo_base64, extensao_arquivo)" +
        " values (@idSolicitacao, @anexo_base64, @extensao_arquivo)";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"idSolicitacao", anexo.IdSolicitacao);
            cmd.Parameters.AddWithValue(@"anexo_base64", anexo.Anexo_Base64);
            cmd.Parameters.AddWithValue(@"extensao_arquivo", anexo.Extensao_Arquivo);


            var result = await base.ExecuteCommand(cmd);
            return result;
        }

        public async Task<bool> ExcluirAnexo(long IdSolicitacao)
        {
            string query = " delete from anexo_solicitacao_tb where idSolicitacao = " + IdSolicitacao;
            var result = await this.ExecuteAsync(query);
            return result; ;
        }

        public async Task<bool> ExcluirSolicitacao(long IdSolicitacao)
        {
            string query = " delete from solicitaco_orcamento_tb where IdSolicitacao = " + IdSolicitacao;

            var result = await this.ExecuteAsync(query);

            return result;
        }

        public async Task<IEnumerable<SolicitacaoOrcamento>> ObterTodosOrcamento(SolicitacaoOrcamento solicitacaoOrcamento)
        {

            string query = "select * from  solicitaco_orcamento_tb ";

            var result = await QueryAsync<SolicitacaoOrcamento>(query);

            return result;
        }

        public async Task<SolicitacaoOrcamento> GetById(long id)
        {
            string query = "select * from  solicitaco_orcamento_tb where IdSolicitacao = " + id;

            var result = await QueryAsync<SolicitacaoOrcamento>(query);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<AnexoSolicitacaoOrcamento>> ObterAnexos(long IdSolicitacao)
        {
            string query = "select * from  anexo_solicitacao_tb where idSolicitacao = " + IdSolicitacao;

            var result = await QueryAsync<AnexoSolicitacaoOrcamento>(query);

            return result;
        }
    }

    
}
