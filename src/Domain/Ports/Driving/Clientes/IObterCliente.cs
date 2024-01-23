using Domain.Models.Clientes;

namespace Domain.Ports.Driving.Clientes;

public interface IObterCliente
{
    Task<Cliente> Executar(string cpf);
}