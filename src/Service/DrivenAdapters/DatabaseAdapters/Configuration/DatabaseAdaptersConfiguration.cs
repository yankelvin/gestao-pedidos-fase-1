using Domain.Models.Clientes;
using Domain.Ports.Driven.Clientes;
using Domain.Ports.Driven.ItensPedido;
using Domain.Ports.Driven.Pedidos;
using Domain.Ports.Driven.Produtos;
using Domain.Ports.Driven.Promocoes;
using Domain.Ports.Driven.Usuarios;
using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DatabaseAdapters;
using Service.DrivenAdapters.DatabaseAdapters.Adapters.Clientes;
using Service.DrivenAdapters.DatabaseAdapters.Adapters.ItensPedido;
using Service.DrivenAdapters.DatabaseAdapters.Adapters.Pedidos;
using Service.DrivenAdapters.DataBaseAdapters.Migrations;
using Service.DrivenAdapters.DatabaseAdapters.Adapters.Promocoes;
using Service.DrivenAdapters.DatabaseAdapters.Adapters.Produtos;
using Service.DrivenAdapters.DatabaseAdapters.Adapters.Usuarios;

namespace Service.DrivenAdapters.DataBaseAdapters.Configuration
{
    public static class DatabaseAdaptersConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string databaseConnection)
        {
            services.AddDbContext<PromocaoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<ProdutoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<UsuarioContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<ClienteContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<PedidoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<ItensPedidoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            
            services.AddHostedService<MigratorHostedService>();

            services.AddTransient<IPromocaoPersistencePort, PromocaoPersistenceAdapter>();
            services.AddTransient<IItemPromocaoPersistencePort, ItemPromocaoPersistenceAdapter>();
            services.AddTransient<IHistoricoUsoPromocaoPersistencePort, HistoricoUsoPromocaoPersistenceAdapter>();
            
            services.AddTransient<IProdutoPersistencePort, ProdutoPersistenceAdapter>();
            services.AddTransient<ICategoriaProdutoPersistencePort, CategoriaProdutoPersistenceAdapter>();
            
            services.AddTransient<IUsuarioPersistencePort, UsuarioPersistenceAdapter>();
            services.AddTransient<IClientePersistenceAdapterPort, ClientePersistenceAdapterPort>();
            services.AddTransient<IPedidoPersistenceAdapterPort, PedidoPersistenceAdapterPort>();
            services.AddTransient<IItensPedidoPersistenceAdapterPort, ItensPedidoPersistenceAdapterPort>();
            return services;
        }
    }
}
