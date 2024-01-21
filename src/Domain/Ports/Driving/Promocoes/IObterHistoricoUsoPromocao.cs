using Domain.Models.Promocoes;

namespace Domain.Ports.Driving.Promocoes
{
    public interface IObterHistoricoUsoPromocao
    {
        Task<IEnumerable<HistoricoUsoPromocao>> Executar(int clienteId);
    }
}
