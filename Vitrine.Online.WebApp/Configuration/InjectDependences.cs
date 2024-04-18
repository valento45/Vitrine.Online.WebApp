using Npgsql;
using System.Data;
using System.Diagnostics;

namespace Vitrine.Online.WebApp.Configuration
{
    public static class InjectDependences
    {


        public static void AddConnection(IServiceCollection services, ConfigurationManager configuration)
        {
            NpgsqlConnection npgsqlConnection;
            var stringConnection = string.Empty;

            if (Debugger.IsAttached)            
                stringConnection = configuration.GetConnectionString("Debug");              
            
            else            
                stringConnection = configuration.GetConnectionString("Production");           


            npgsqlConnection = new NpgsqlConnection(stringConnection);
            services.AddSingleton<IDbConnection>(npgsqlConnection);
        }

        public static void AddRepositorys(IServiceCollection services)
        {

        }

        public static void AddServices (IServiceCollection services)
        {

        }
    }
}
