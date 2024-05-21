using Vitrine.Online.Core.Repositorys;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitrine.Online.Core.Models.services;
using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using Vitrine.Online.Core.Repositorys.Interfaces;

namespace Vitrine.Online.Core.Repositorys
{
    public class ServicoRealizadoRepository : RepositoryBase, IServicoRealizadoRepository
    {
        public ServicoRealizadoRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
        public async Task<bool> InserirServicoRealizado(ServicosRealizado servicosRealizado)
        {
            string query = "insert into servico_realizado_tb" +
                "(IdCategoria, DescricaoServico, DataServico, ResumoServico, EnderecoServico)" +
                "values (@IdCategoria, @Descricao, @DataServico, @ResumoServico, @EnderecoServico) returning IdServico;";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue("@IdCategoria", servicosRealizado.IdCategoria);
            cmd.Parameters.AddWithValue("@Descricao", servicosRealizado.DescricaoServico ?? "");
            cmd.Parameters.AddWithValue("@DataServico", servicosRealizado.DataServico);
            cmd.Parameters.AddWithValue("@ResumoServico", servicosRealizado.ResumoServico ?? "");
            cmd.Parameters.AddWithValue("@EnderecoServico", servicosRealizado.EnderecoServico ?? "");


            var result = await base.ExecuteScalarAsync(cmd);

            if (result != null)
            {
                servicosRealizado.IdServico = long.Parse(result.ToString());
            }

            return servicosRealizado.IdServico > 0;
        }
        public async Task<bool> AtualizarServicoRealizado(ServicosRealizado servicosRealizado)
        {
            string query = "update servico_realizado_tb set IdCategoria = @IdCategoria, Descricao = @Descricao," +
                 "DataServico = @DataServico, ResumoServico = @ResumoServico, EnderecoServico = @EnderecoServico " +
                 "where IdServico = @IdServico;";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue("@IdServico", servicosRealizado.IdServico);
            cmd.Parameters.AddWithValue("@IdCategoria", servicosRealizado.IdCategoria);
            cmd.Parameters.AddWithValue("@Descricao", servicosRealizado.DescricaoServico);
            cmd.Parameters.AddWithValue("@DataServico", servicosRealizado.DataServico);
            cmd.Parameters.AddWithValue("@ResumoServico", servicosRealizado.ResumoServico);
            cmd.Parameters.AddWithValue("@EnderecoServico", servicosRealizado.EnderecoServico);

            return await base.ExecuteCommand(cmd);
        }
        public async Task<bool> IncluirAnexoServicoRealizado(AnexoServicosRealizado anexo)
        {
            string query = "insert into anexo_servico_realizado_tb (IdServico, AnexoBase64, ExtensaoArquivo)" +
            " values (@IdServico, @AnexoBase64, @ExtensaoArquivo)";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"IdServico", anexo.IdServico);
            cmd.Parameters.AddWithValue(@"AnexoBase64", anexo.AnexoBase64);
            cmd.Parameters.AddWithValue(@"ExtensaoArquivo", anexo.ExtensaoArquivo);


            var result = await base.ExecuteCommand(cmd);
            return result;
        }


        public async Task<bool> ExcluirAnexo(long id)
        {
            string query = "delete from anexo_servico_realizado_tb where IdServico = " + id;

            var result = await this.ExecuteAsync(query);
            return result; ;
        }

        public async Task<bool> ExcluirServicoRealizado(long id)
        {
            string query = "delete from servico_realizado_tb where IdServico =" + id;
            var result = await this.ExecuteAsync(query);

            return result;
        }

        public async Task<ServicosRealizado> GetById(long IdServico)
        {
            string query = "select * from  servico_realizado_tb where IdServico = " + IdServico;

            var result = await QueryAsync<ServicosRealizado>(query);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<AnexoServicosRealizado>> ObterAnexos(long IdServico)
        {
            string query = "select * from  anexo_servico_realizado_tb where IdServico = " + IdServico;

            var result = await QueryAsync<AnexoServicosRealizado>(query);

            return result;
        }

        public async Task<IEnumerable<ServicosRealizado>> ObterTodosServicosRealizado()
        {

            string query = "select * from  servico_realizado_tb ";

            var result = await QueryAsync<ServicosRealizado>(query);

            return result;
        }
    }
}
