using Domain.Ports.Driven.Promocoes;
using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DatabaseAdapters;
using Service.DrivenAdapters.DatabaseAdapters.Adapters.Promocoes;
using Service.DrivenAdapters.DataBaseAdapters.Migrations;

namespace Service.DrivenAdapters.DataBaseAdapters.Configuration
{
    public static class DatabaseAdaptersConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string databaseConnection)
        {
            services.AddDbContext<PromocaoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddHostedService<MigratorHostedService>();

            services.AddTransient<IPromocaoPersistencePort, PromocaoPersistenceAdapter>();
            services.AddTransient<IItemPromocaoPersistencePort, ItemPromocaoPersistenceAdapter>();
            services.AddTransient<IHistoricoUsoPromocaoPersistencePort, HistoricoUsoPromocaoPersistenceAdapter>();

            return services;
        }
    }
}
