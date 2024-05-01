using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitrine.Online.Core.Repositorys
{
    public class RepositoryBase
    {
        protected readonly IDbConnection _dbConnection;

        public RepositoryBase(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> ExecuteAsync(string query, object value = null)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();

                var result = await _dbConnection.ExecuteAsync(query, value);

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _dbConnection.Close();
            }
        }



        public async Task<object> ExecuteScalar(IDbCommand dbCommand)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();

                dbCommand.Connection = _dbConnection;

                var result = dbCommand.ExecuteScalar();

                if (result != null)
                    return result;
                else
                    throw new ArgumentNullException($"Command: {dbCommand.CommandText} \r\n\r\n\r\n" + nameof(dbCommand));
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
            finally
            {
                _dbConnection.Close();
            }

        }
    }
}
