using AutoMapper;
using Domain.Models.Promocoes;
using Domain.Ports.Driven.Promocoes;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes;

namespace Service.DrivenAdapters.DatabaseAdapters.Adapters.Promocoes
{
    public class ItemPromocaoPersistenceAdapter : IItemPromocaoPersistencePort
    {
        private readonly IMapper _mapper;
        private readonly PromocaoContext _promocaoContext;

        public ItemPromocaoPersistenceAdapter(IMapper mapper, PromocaoContext promocaoContext)
        {
            _mapper = mapper;
            _promocaoContext = promocaoContext;
        }

        public async Task Cadastrar(ItemPromocao itemPromocao)
        {
            var entity = _mapper.Map<ItemPromocaoEntity>(itemPromocao);
            await _promocaoContext.ItensPromocoes.AddAsync(entity);
            await _promocaoContext.SaveChangesAsync();
        }

        public async Task Atualizar(ItemPromocao itemPromocao)
        {
            var entity = _mapper.Map<ItemPromocaoEntity>(itemPromocao);
            _promocaoContext.ItensPromocoes.Update(entity);
            await _promocaoContext.SaveChangesAsync();
        }

        public Task<IEnumerable<ItemPromocao>> ObterPorPromocao(int promocaoId)
        {
            var entities = _promocaoContext.ItensPromocoes.Where(i => i.idpromocao.Equals(promocaoId));
            var itensPromocao = _mapper.Map<IEnumerable<ItemPromocao>>(entities);
            return Task.FromResult(itensPromocao);
        }

        public Task<IEnumerable<ItemPromocao>> ObterPorProduto(int produtoId)
        {
            var entities = _promocaoContext.ItensPromocoes.Where(i => i.idproduto.Equals(produtoId));
            var itensPromocao = _mapper.Map<IEnumerable<ItemPromocao>>(entities);
            return Task.FromResult(itensPromocao);
        }

        public async Task Remover(int promocaoId)
        {
            var entity = _promocaoContext.ItensPromocoes.FirstOrDefault(p => p.idpromocao.Equals(promocaoId));

            if (entity != null)
            {
                _promocaoContext.ItensPromocoes.Remove(entity);
                await _promocaoContext.SaveChangesAsync();
            }
            else
                throw new KeyNotFoundException($"Identificador da promocao inexistente. {promocaoId}");
        }
    }
}
