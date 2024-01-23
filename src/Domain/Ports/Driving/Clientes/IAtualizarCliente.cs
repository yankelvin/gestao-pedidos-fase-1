using Domain.Models.Clientes;

namespace Domain.Ports.Driving.Clientes;

public interface IAtualizarCliente
{
    Task Executar(Cliente cliente);
}