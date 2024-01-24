using Domain.Models.Pedidos;
using Domain.Ports.Driven.ItensPedido;
using Domain.Ports.Driven.Pedidos;
using Domain.Ports.Driving.Pedidos;

namespace Domain.UseCases.Pedidos;

public class CadastrarPedido : ICadastrarPedido
{
    private readonly IPedidoPersistenceAdapterPort _pedidoPersistenceAdapterPort;
    private readonly IItensPedidoPersistenceAdapterPort _itensPedidoPersistenceAdapterPort;
    
    public CadastrarPedido(IPedidoPersistenceAdapterPort pedidoPersistenceAdapterPort, IItensPedidoPersistenceAdapterPort itensPedidoPersistenceAdapterPort)
    {
        _pedidoPersistenceAdapterPort = pedidoPersistenceAdapterPort;
        _itensPedidoPersistenceAdapterPort = itensPedidoPersistenceAdapterPort;
    }

    public void Executar(Pedido pedido, IEnumerable<int> produtoList)
    {
        pedido.DataPedido = DateTime.Now;
        pedido.HoraInicio = pedido.DataPedido;

        var pedidoId = _pedidoPersistenceAdapterPort.Inserir(pedido);

        _itensPedidoPersistenceAdapterPort.Insert(pedidoId, produtoList);
        
        _pedidoPersistenceAdapterPort.SaveChanges();
    }
}