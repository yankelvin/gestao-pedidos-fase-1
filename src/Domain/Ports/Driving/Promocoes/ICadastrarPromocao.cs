using Domain.Models.Promocoes;

namespace Domain.Ports.Driving.Promocoes
{
    public interface ICadastrarPromocao
    {
        Task Executar(Promocao promocao);
    }
}
