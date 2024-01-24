namespace Domain.Ports.Driven.Pedidos;

public interface IDeletarPedido
{
    bool Executar(int id);
}