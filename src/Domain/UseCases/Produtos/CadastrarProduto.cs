using Domain.Models.Produtos;
using Domain.Ports.Driven.Produtos;
using Domain.Ports.Driving.Produtos;

namespace Domain.UseCases.Produtos
{
    public class CadastrarProduto : ICadastrarProduto
    {
        private readonly IProdutoPersistencePort _produtoPersistencePort;

        public CadastrarProduto(IProdutoPersistencePort produtoPersistencePort)
        {
            _produtoPersistencePort = produtoPersistencePort;
        }

        public async Task Executar(Produto produto)
        {
            await _produtoPersistencePort.Cadastrar(produto);
        }
    }
}
