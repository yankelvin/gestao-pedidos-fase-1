using AutoMapper;
using Domain.Models.Promocoes;
using Domain.Ports.Driven.Promocoes;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes;

namespace Service.DrivenAdapters.DatabaseAdapters.Adapters.Promocoes
{
    public class PromocaoPersistenceAdapter : IPromocaoPersistencePort
    {
        private readonly IMapper _mapper;
        private readonly PromocaoContext _promocaoContext;

        public PromocaoPersistenceAdapter(IMapper mapper, PromocaoContext promocaoContext)
        {
            _mapper = mapper;
            _promocaoContext = promocaoContext;
        }

        public async Task Cadastrar(Promocao promocao)
        {
            var entity = _mapper.Map<PromocaoEntity>(promocao);
            await _promocaoContext.Promocoes.AddAsync(entity);
            await _promocaoContext.SaveChangesAsync();
        }

        public async Task Atualizar(Promocao promocao)
        {
            var entity = _mapper.Map<PromocaoEntity>(promocao);
            _promocaoContext.Promocoes.Update(entity);
            await _promocaoContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Promocao>> Obter()
        {
            var entities = _promocaoContext.Promocoes.ToList();
            var promocoes = _mapper.Map<IEnumerable<Promocao>>(entities);
            return Task.FromResult(promocoes);
        }

        public async Task<bool> Existe(int promocaoId) => await Obter(promocaoId) is not null;
        public async Task<bool> NaoExiste(int promocaoId) => await Existe(promocaoId) is false;
        

        public Task<Promocao?> Obter(int promocaoId)
        {
            var entity = _promocaoContext.Promocoes.FirstOrDefault(p => p.Id.Equals(promocaoId));
            if (entity == null)
                throw new KeyNotFoundException($"Identificador da promocao inexistente. {promocaoId}");

            var promocao = _mapper.Map<Promocao>(entity);
            return Task.FromResult(promocao);
        }

        public async Task Remover(int promocaoId)
        {
            var entity = _promocaoContext.Promocoes.FirstOrDefault(p => p.Id.Equals(promocaoId));

            if (entity != null)
            {
                _promocaoContext.Promocoes.Remove(entity);
                await _promocaoContext.SaveChangesAsync();
            }
            else
                throw new KeyNotFoundException($"Identificador da promocao inexistente. {promocaoId}");
        }

        public void RegistrarUsoPromocao(int clienteId, int promocaoId)
        {
            _promocaoContext.HistoricosUsoPromocoes.Add(new HistoricoUsoPromocaoEntity()
            {
                idCliente = clienteId,
                idPromocao = promocaoId,
                utilizado = true
            });

            _promocaoContext.SaveChanges();
        }
    }
}
