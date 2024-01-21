using Domain.Ports.Driving.Promocoes;
using Domain.UseCases.Promocoes;

namespace Service.DrivingAdapters.Configuration
{
    public static class UseCaseConfiguration
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IAtualizarItemPromocao, AtualizarItemPromocao>();
            services.AddTransient<IAtualizarPromocao, AtualizarPromocao>();
            services.AddTransient<ICadastrarHistoricoUsoPromocao, CadastrarHistoricoUsoPromocao>();
            services.AddTransient<ICadastrarItemPromocao, CadastrarItemPromocao>();
            services.AddTransient<ICadastrarPromocao, CadastrarPromocao>();
            services.AddTransient<IObterItemPromocao, ObterItemPromocao>();
            services.AddTransient<IObterPromocao, ObterPromocao>();
            services.AddTransient<IObterHistoricoUsoPromocao, ObterHistoricoUsoPromocao>();
            services.AddTransient<IRemoverItemPromocao, RemoverItemPromocao>();
            services.AddTransient<IRemoverPromocao, RemoverPromocao>();

            return services;
        }
    }
}
