using Domain.Models.Promocoes;

namespace Domain.Ports.Driving.Promocoes
{
    public interface ICadastrarItemPromocao
    {
        Task Executar(ItemPromocao itemPromocao);
    }
}
