using Domain.Models.Promocoes;

namespace Domain.Ports.Driven.Promocoes
{
    public interface IHistoricoUsoPromocaoPersistencePort
    {
        Task InserirUsoPromocao(HistoricoUsoPromocao historicoUsoPromocao);
        Task<IEnumerable<HistoricoUsoPromocao>> ObterPorCliente(int clienteId);
    }
}
