using Domain.Enumerators;
using Domain.Models.Pedidos;
using Domain.Models.Produtos;
using Domain.Ports.Driven.Clientes;
using Domain.Ports.Driven.ItensPedido;
using Domain.Ports.Driven.Pedidos;
using Domain.Ports.Driven.Produtos;
using Domain.Ports.Driving.Pedidos;

namespace Domain.UseCases.Pedidos;

public class CadastrarPedido : ICadastrarPedido
{
    private readonly IPedidoPersistenceAdapterPort _pedidoPersistenceAdapterPort;
    private readonly IItensPedidoPersistenceAdapterPort _itensPedidoPersistenceAdapterPort;
    private readonly IProdutoPersistencePort _produtoPersistencePort;
    private readonly IClientePersistenceAdapterPort _clientePersistenceAdapterPort;
    
    public CadastrarPedido(IPedidoPersistenceAdapterPort pedidoPersistenceAdapterPort, IItensPedidoPersistenceAdapterPort itensPedidoPersistenceAdapterPort, IProdutoPersistencePort produtoPersistencePort, IClientePersistenceAdapterPort clientePersistenceAdapterPort)
    {
        _pedidoPersistenceAdapterPort = pedidoPersistenceAdapterPort;
        _itensPedidoPersistenceAdapterPort = itensPedidoPersistenceAdapterPort;
        _produtoPersistencePort = produtoPersistencePort;
        _clientePersistenceAdapterPort = clientePersistenceAdapterPort;
    }

    public async Task ExecutarAsync(int idCliente, IEnumerable<int> produtoList)
    {
        if (_clientePersistenceAdapterPort.NaoExiste(idCliente))
            throw new ArgumentException("Cliente informado não existe");
        
        var pedido = await ComplementaDadosPeddidoAsync(idCliente, produtoList);

        _pedidoPersistenceAdapterPort.Inserir(pedido, produtoList);
        
        _pedidoPersistenceAdapterPort.SaveChanges();

        // _itensPedidoPersistenceAdapterPort.Insert(pedidoEntity, produtoList);
        // _itensPedidoPersistenceAdapterPort.SaveChanges();
    }

    private async Task<Pedido> ComplementaDadosPeddidoAsync(int idCliente, IEnumerable<int> produtoIdList)
    {
        IEnumerable<Produto> produtoList = await _produtoPersistencePort.Obter();

        return new()
        {
            DataPedido = DateTime.Now,
            HorarioInicio = DateTime.Now,
            Status = Status.Solicitado,
            ValorPedido = produtoList.Where(p => produtoIdList.Contains(p.Id)).Sum(p => p.Preco),
            IdCliente = idCliente
        };
    }
}