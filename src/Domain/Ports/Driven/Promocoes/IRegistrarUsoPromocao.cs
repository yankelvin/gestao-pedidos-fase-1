namespace Domain.Ports.Driven.Promocoes;

public interface IRegistrarUsoPromocao
{
    Task Executar(int clienteId, int promocaoId);
}