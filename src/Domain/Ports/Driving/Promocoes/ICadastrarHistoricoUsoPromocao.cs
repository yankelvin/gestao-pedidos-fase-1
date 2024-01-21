using Domain.Models.Promocoes;

namespace Domain.Ports.Driving.Promocoes
{
    public interface ICadastrarHistoricoUsoPromocao
    {
        Task Executar(HistoricoUsoPromocao historicoUsoPromocao);
    }
}
