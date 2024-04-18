using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitrine.Online.Core.Entities.Categoria;
using Vitrine.Online.Core.Repositorys.Interfaces;

namespace Vitrine.Online.Core.Repositorys
{
    public class CategoriaRepository : RepositoryBase, ICategoriaRepository
    {


        public CategoriaRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }

        public async Task<bool> Inserir(Categoria categoria)
        {
            string query = "INSERT INTO categoria.tb (NomeCategoria, Descricao) VALUES (@NomeCategoria, @Descricao) returning IdCategoria;";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"NomeCategoria", categoria.NomeCategoria);
            cmd.Parameters.AddWithValue(@"Descricao", categoria.Descricao);

            var result = await base.ExecuteScalar(cmd);

            if (result != null)
            {
                categoria.IdCategoria = int.Parse(result?.ToString() ?? "-1");
                return true;
            }
            else
                return false;
        }

        public async Task<bool> Atualizar(Categoria categoria)
        {
            string query = "UPDATE categoria_tb set NomeCategoria = @NomeCategoria, Descricao = @Descricao WHERE IdCategoria = @IdCategoria";
            return await base.ExecuteAsync(query, categoria);
        }

        public Task<bool> Excluir(int idCategoria)
        {
            string query = "DELETE FROM categoria_tb WHRE IdCategoria = " + idCategoria;
            return base.ExecuteAsync(query);
        }
    }
}
