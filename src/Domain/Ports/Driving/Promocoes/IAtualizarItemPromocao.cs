using Domain.Models.Promocoes;

namespace Domain.Ports.Driving.Promocoes
{
    public interface IAtualizarItemPromocao
    {
        Task Executar(ItemPromocao itemPromocao);
    }
}
