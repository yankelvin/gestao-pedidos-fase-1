using Domain.Ports.Driven.Promocoes;
using Domain.Ports.Driving.Promocoes;

namespace Domain.UseCases.Promocoes
{
    public class RemoverItemPromocao : IRemoverItemPromocao
    {
        private readonly IItemPromocaoPersistencePort _itemPromocaoPersistencePort;

        public RemoverItemPromocao(IItemPromocaoPersistencePort itemPromocaoPersistencePort)
        {
            _itemPromocaoPersistencePort = itemPromocaoPersistencePort;
        }

        public async Task Executar(int promocaoId)
        {
            await _itemPromocaoPersistencePort.Remover(promocaoId);
        }
    }
}
