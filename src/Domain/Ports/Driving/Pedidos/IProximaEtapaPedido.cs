using Domain.Enumerators;

namespace Domain.Ports.Driving.Pedidos;

public interface IProximaEtapaPedido
{
    StatusPedido Executar(int idPedido);
}