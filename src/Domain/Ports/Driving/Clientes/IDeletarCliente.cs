namespace Domain.Ports.Driving.Clientes;

public interface IDeletarCliente
{
    Task Executar(int id);
}