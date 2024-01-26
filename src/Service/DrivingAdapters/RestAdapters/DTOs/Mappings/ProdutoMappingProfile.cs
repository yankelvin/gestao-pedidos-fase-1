using AutoMapper;
using Domain.Models.Produtos;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Produtos;

namespace Service.DrivingAdapters.RestAdapters.DTOs.Mappings
{
    public class ProdutoMappingProfile : Profile
    {
        public ProdutoMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>();
            CreateMap<Produto, ProdutoEntity>();
            CreateMap<ProdutoEntity, Produto>().ConstructUsing(p => new Produto(p.Id, p.Nome, p.Status, p.IdCategoria, p.Preco));
            CreateMap<ProdutoDTO, Produto>().ConstructUsing(p => new Produto(p.Id, p.Nome, p.Status, p.IdCategoria, p.Preco));

            CreateMap<CategoriaProduto, CategoriaProdutoDTO>();
            CreateMap<CategoriaProduto, CategoriaProdutoEntity>();
            CreateMap<CategoriaProdutoEntity, CategoriaProduto>().ConstructUsing(c => new CategoriaProduto(c.Id, c.Nome));
            CreateMap<CategoriaProdutoDTO, CategoriaProduto>().ConstructUsing(c => new CategoriaProduto(c.Id, c.Nome));
        }
    }
}
