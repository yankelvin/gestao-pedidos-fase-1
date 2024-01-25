using Domain.Models.Clientes;

namespace Domain.Ports.Driving.Clientes;

public interface IObterCliente
{
    Cliente? Executar(string cpf);
}