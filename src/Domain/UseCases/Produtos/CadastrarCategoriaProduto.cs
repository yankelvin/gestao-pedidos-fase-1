using Domain.Models.Produtos;
using Domain.Ports.Driven.Produtos;
using Domain.Ports.Driving.Produtos;

namespace Domain.UseCases.Produtos
{
    public class CadastrarCategoriaProduto : ICadastrarCategoriaProduto
    {
        private readonly ICategoriaProdutoPersistencePort _categoriaProdutoPersistencePort;

        public CadastrarCategoriaProduto(ICategoriaProdutoPersistencePort categoriaProdutoPersistencePort)
        {
            _categoriaProdutoPersistencePort = categoriaProdutoPersistencePort;
        }

        public async Task Executar(CategoriaProduto categoriaProduto)
        {
            await _categoriaProdutoPersistencePort.Cadastrar(categoriaProduto);
        }
    }
}