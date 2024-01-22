using Domain.Ports.Driven.Produtos;
using Domain.Ports.Driving.Produtos;

namespace Domain.UseCases.Produtos
{
    public class RemoverCategoriaProduto : IRemoverCategoriaProduto
    {
        private readonly ICategoriaProdutoPersistencePort _categoriaProdutoPersistencePort;

        public RemoverCategoriaProduto(ICategoriaProdutoPersistencePort categoriaProdutoPersistencePort)
        {
            _categoriaProdutoPersistencePort = categoriaProdutoPersistencePort;
        }

        public async Task Executar(int categoriaId)
        {
            await _categoriaProdutoPersistencePort.Remover(categoriaId);
        }
    }
}