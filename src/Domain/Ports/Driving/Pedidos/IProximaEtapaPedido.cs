using Domain.Enumerators;

namespace Domain.Ports.Driving.Pedidos;

public interface IProximaEtapaPedido
{
    Status Executar(int idPedido);
}