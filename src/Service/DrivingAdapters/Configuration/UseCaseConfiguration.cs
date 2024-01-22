﻿using Domain.Ports.Driving.Produtos;
using Domain.Ports.Driving.Promocoes;
using Domain.Ports.Driving.Usuarios;
using Domain.UseCases.Produtos;
using Domain.UseCases.Promocoes;
using Domain.UseCases.Usuarios;

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
            services.AddTransient<IRemoverItemPromocao, RemoverItemPromocao>();
            services.AddTransient<IRemoverPromocao, RemoverPromocao>();

            services.AddTransient<IObterProduto, ObterProduto>();
            services.AddTransient<IObterCategoriaProduto, ObterCategoriaProduto>();
            services.AddTransient<IRemoverProduto, RemoverProduto>();
            services.AddTransient<IRemoverCategoriaProduto, RemoverCategoriaProduto>();
            services.AddTransient<IAtualizarProduto, AtualizarProduto>();
            services.AddTransient<IAtualizarCategoriaProduto, AtualizarCategoriaProduto>();
            services.AddTransient<ICadastrarProduto, CadastrarProduto>();
            services.AddTransient<ICadastrarCategoriaProduto, CadastrarCategoriaProduto>();

            services.AddTransient<IObterUsuario, ObterUsuario>();
            services.AddTransient<IRemoverUsuario, RemoverUsuario>();
            services.AddTransient<IAtualizarUsuario, AtualizarUsuario>();
            services.AddTransient<ICadastrarUsuario, CadastrarUsuario>();

            return services;
        }
    }
}
