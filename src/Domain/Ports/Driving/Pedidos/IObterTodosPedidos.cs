using Domain.Enumerators;
using Domain.Models.Pedidos;

namespace Domain.Ports.Driving.Pedidos;

public interface IObterTodosPedidos
{
    IEnumerable<Pedido> Executar(int? idCliente, Status? statusPedido);
}