using Domain.Models.Produtos;
using Domain.Ports.Driven.Produtos;
using Domain.Ports.Driving.Produtos;

namespace Domain.UseCases.Produtos
{
    public class ObterCategoriaProduto : IObterCategoriaProduto
    {
        private readonly ICategoriaProdutoPersistencePort _categoriaProdutoPersistencePort;

        public ObterCategoriaProduto(ICategoriaProdutoPersistencePort categoriaProdutoPersistencePort)
        {
            _categoriaProdutoPersistencePort = categoriaProdutoPersistencePort;
        }

        public Task<IEnumerable<CategoriaProduto>> Executar()
        {
            return _categoriaProdutoPersistencePort.Obter();
        }

        public Task<CategoriaProduto?> Executar(int categoriaId)
        {
            return _categoriaProdutoPersistencePort.Obter(categoriaId);
        }
    }
}