using Domain.Models.Clientes;

namespace Domain.Ports.Driven.Clientes;

public interface IClientePersistenceAdapterPort
{
    Cliente? ObterPorCpf(string cpf);
    bool NaoExiste(int id);
    bool Existe(int id);
    bool ExistePorCpf(string cpf);
    Task InserirAsync(Cliente cliente);
    bool Deletar(int id);
    bool Atualizar(Cliente cliente);
}