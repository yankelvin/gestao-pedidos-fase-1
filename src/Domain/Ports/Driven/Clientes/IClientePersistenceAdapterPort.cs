using Domain.Models.Clientes;

namespace Domain.Ports.Driven.Clientes;

public interface IClientePersistenceAdapterPort
{
    Cliente? FindByCpf(string cpf);
    bool Exists(string cpf);
    Task InsertAsync(Cliente cliente);
}