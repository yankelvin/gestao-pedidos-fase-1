using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DatabaseAdapters;

namespace Service.DrivenAdapters.DataBaseAdapters.Migrations
{
    public class MigratorHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public MigratorHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using IServiceScope scope = _serviceProvider.CreateScope();
            PromocaoContext promocaoContext = scope.ServiceProvider.GetRequiredService<PromocaoContext>();
            ProdutoContext produtoContext = scope.ServiceProvider.GetRequiredService<ProdutoContext>();
            UsuarioContext usuarioContext = scope.ServiceProvider.GetRequiredService<UsuarioContext>();
            ClienteContext clienteContext = scope.ServiceProvider.GetRequiredService<ClienteContext>();

            //await promocaoContext.Database.MigrateAsync(cancellationToken: cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
