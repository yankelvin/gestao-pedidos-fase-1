using Domain.Models.Promocoes;

namespace Domain.Ports.Driven.Promocoes
{
    public interface IPromocaoPersistencePort
    {
        Task<IEnumerable<Promocao>> Obter();
        Task<Promocao?> Obter(int promocaoId);
        Task Cadastrar(Promocao promocao);
        Task Atualizar(Promocao promocao);
        Task Remover(int promocaoId);
    }
}
