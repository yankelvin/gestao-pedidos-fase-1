using Domain.Models.Clientes;

namespace Domain.Ports.Driving.Clientes;

public interface IAtualizarCliente
{
    bool Executar(Cliente cliente);
}