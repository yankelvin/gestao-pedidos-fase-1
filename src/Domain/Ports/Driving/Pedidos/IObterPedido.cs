using Domain.Models.Pedidos;

namespace Domain.Ports.Driving.Pedidos;

public interface IObterPedido
{
    Pedido Executar(int id);
}