using Domain.Models.Promocoes;

namespace Domain.Ports.Driving.Promocoes
{
    public interface IObterPromocao
    {
        Task<IEnumerable<Promocao>> Executar();
        Task<Promocao?> Executar(int promocaoId);
    }
}
