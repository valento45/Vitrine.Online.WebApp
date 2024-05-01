using Npgsql;
using System.Data;
using System.Diagnostics;
using Vitrine.Online.Core.Repositorys;
using Vitrine.Online.Core.Repositorys.Interfaces;
using Vitrine.Online.Core.Services;
using Vitrine.Online.Core.Services.Intefaces;
using Vitrine.Online.WebApp.Application;
using Vitrine.Online.WebApp.Application.Interfaces;

namespace Vitrine.Online.WebApp.Configuration
{
    public static class InjectDependences
    {


        public static void AddConnection(this IServiceCollection services, ConfigurationManager configuration)
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

        public static void AddRepositorys(this IServiceCollection services)
        {
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();

        }

        public static void AddServices (this IServiceCollection services)
        {
            services.AddTransient<ICategoriaService, CategoriaService>();
        }

        public static void AddApplications(this IServiceCollection services)
        {
            services.AddTransient<ICategoriaApplication, CategoriaApplication>();
        }
    }
}
