using Domain.Ports.Driven.Clientes;
using Domain.Ports.Driven.Promocoes;

namespace Domain.UseCases.Promocoes;

public class RegistrarUsoPromocao : IRegistrarUsoPromocao
{
    private readonly IPromocaoPersistencePort _promocaoPersistencePort;
    private readonly IClientePersistenceAdapterPort _clientePersistenceAdapterPort;

    public RegistrarUsoPromocao(IPromocaoPersistencePort promocaoPersistencePort, IClientePersistenceAdapterPort clientePersistenceAdapterPort)
    {
        _promocaoPersistencePort = promocaoPersistencePort;
        _clientePersistenceAdapterPort = clientePersistenceAdapterPort;
    }

    public async Task Executar(int clienteId, int promocaoId)
    {
        if (_clientePersistenceAdapterPort.NaoExiste(clienteId))
            throw new ArgumentException("Cliente não cadastrado");

        if(await _promocaoPersistencePort.NaoExiste(promocaoId))
            throw new ArgumentException("Promoção não cadastrada");
        
        _promocaoPersistencePort.RegistrarUsoPromocao(clienteId, promocaoId);
    }
}