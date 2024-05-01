using Dapper;
using Expert.Gov.Core.Repositorys;
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
            string query = "INSERT INTO categoria.tb (NomeCategoria, Descricao, ImagemBase64)" +
                " VALUES (@NomeCategoria, @Descricao, @ImagemBase64) returning IdCategoria;";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"NomeCategoria", categoria.NomeCategoria);
            cmd.Parameters.AddWithValue(@"Descricao", categoria.Descricao);
            cmd.Parameters.AddWithValue(@"ImagemBase64", categoria.ImagemBase64);

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
            string query = "UPDATE categoria_tb set NomeCategoria = @NomeCategoria, Descricao = @Descricao, ImagemBase64 = @ImagemBase64" +
                " WHERE IdCategoria = @IdCategoria";
            return await base.ExecuteAsync(query, categoria);
        }

        public Task<bool> Excluir(int idCategoria)
        {
            string query = "DELETE FROM categoria_tb WHERE IdCategoria = " + idCategoria;
            return base.ExecuteAsync(query);
        }

        public async Task<IEnumerable<Categoria>> GetAll(int limit = 0)
        {
            string query = "select * from categoria_tb ";

            if (limit > 0)
                query += $" limit {limit}";

            return await _dbConnection.QueryAsync<Categoria>(query);
        }
    }
}
