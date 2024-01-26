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
        void RegistrarUsoPromocao(int clienteId, int promocaoId);
        Task<bool> NaoExiste(int promocaoId);
    }
}
