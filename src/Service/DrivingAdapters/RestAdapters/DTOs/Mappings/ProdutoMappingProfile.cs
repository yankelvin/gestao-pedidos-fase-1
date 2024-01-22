﻿using AutoMapper;
using Domain.Models.Produtos;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Produtos;

namespace Service.DrivingAdapters.RestAdapters.DTOs.Mappings
{
    public class ProdutoMappingProfile : Profile
    {
        public ProdutoMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>();
            CreateMap<CategoriaProduto, CategoriaProdutoDTO>();
            CreateMap<ProdutoEntity, Produto>().ConstructUsing(p => new Produto(p.Id, p.Nome, p.Ativo, p.IdCategoria, p.Preco));
        }
    }
}
