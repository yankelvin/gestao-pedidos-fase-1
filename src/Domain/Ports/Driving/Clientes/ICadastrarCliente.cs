using Domain.Models.Clientes;

namespace Domain.Ports.Driving.Clientes;

public interface ICadastrarCliente
{
    Task Executar(Cliente cliente);
}