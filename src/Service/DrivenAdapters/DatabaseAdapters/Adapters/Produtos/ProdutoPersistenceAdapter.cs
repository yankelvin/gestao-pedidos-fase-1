using AutoMapper;
using Domain.Models.Produtos;
using Domain.Ports.Driven.Produtos;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Produtos;

namespace Service.DrivenAdapters.DatabaseAdapters.Adapters.Produtos
{
    public class ProdutoPersistenceAdapter : IProdutoPersistencePort
    {
        private readonly IMapper _mapper;
        private readonly ProdutoContext _produtoContext;

        public ProdutoPersistenceAdapter(IMapper mapper, ProdutoContext produtoContext)
        {
            _mapper = mapper;
            _produtoContext = produtoContext;
        }

        public async Task Cadastrar(Produto produto)
        {
            var entity = _mapper.Map<ProdutoEntity>(produto);
            await _produtoContext.Produtos.AddAsync(entity);
            await _produtoContext.SaveChangesAsync();
        }

        public async Task Atualizar(Produto produto)
        {
            var entity = _mapper.Map<ProdutoEntity>(produto);
            _produtoContext.Produtos.Update(entity);
            await _produtoContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Produto>> Obter()
        {
            var entities = _produtoContext.Produtos.ToList();
            var produtos = _mapper.Map<IEnumerable<Produto>>(entities);
            return Task.FromResult(produtos);
        }

        public Task<Produto?> Obter(int produtoId)
        {
            var entity = _produtoContext.Produtos.FirstOrDefault(p => p.Id.Equals(produtoId));
            if (entity == null)
                throw new KeyNotFoundException($"Identificador do Produto inexistente. {produtoId}");

            var produto = _mapper.Map<Produto>(entity);
            return Task.FromResult(produto);
        }

        public async Task Remover(int produtoId)
        {
            var entity = _produtoContext.Produtos.FirstOrDefault(p => p.Id.Equals(produtoId));

            if (entity != null)
            {
                _produtoContext.Produtos.Remove(entity);
                await _produtoContext.SaveChangesAsync();
            }
            else
                throw new KeyNotFoundException($"Identificador do Produto inexistente. {produtoId}");
        }

        public Task<IEnumerable<Produto>> ObterPorCategoria(int categoriaId)
        {
            var entities = _produtoContext.Produtos.Where(i => i.IdCategoria.Equals(categoriaId));
            var produtos = _mapper.Map<IEnumerable<Produto>>(entities);
            return Task.FromResult(produtos);
        }
    }
}
