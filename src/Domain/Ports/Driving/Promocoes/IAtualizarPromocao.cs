using Domain.Models.Promocoes;

namespace Domain.Ports.Driving.Promocoes
{
    public interface IAtualizarPromocao
    {
        Task Executar(Promocao promocao);
    }
}
