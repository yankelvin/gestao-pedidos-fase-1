using AutoMapper;
using Domain.Models.Promocoes;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes;

namespace Service.DrivingAdapters.RestAdapters.DTOs.Mappings
{
    public class PromocaoMappingProfile : Profile
    {
        public PromocaoMappingProfile()
        {
            CreateMap<Promocao, PromocaoDTO>();
            CreateMap<Promocao, PromocaoEntity>();
            CreateMap<PromocaoEntity, Promocao>().ConstructUsing(p => new Promocao(p.Id, p.texto, p.status));
            CreateMap<PromocaoDTO, Promocao>().ConstructUsing(p => new Promocao(p.Texto, p.Status));

            CreateMap<ItemPromocao, ItemPromocaoDTO>();
            CreateMap<ItemPromocao, ItemPromocaoEntity>();
            CreateMap<ItemPromocaoEntity, ItemPromocao>().ConstructUsing(p => new ItemPromocao(p.idpromocao, p.idproduto, p.desconto));
            CreateMap<ItemPromocaoDTO, ItemPromocao>().ConstructUsing(p => new ItemPromocao(p.IdPromocao, p.IdProduto, p.Desconto));

            CreateMap<HistoricoUsoPromocao, HistoricoUsoPromocaoDTO>();
            CreateMap<HistoricoUsoPromocao, HistoricoUsoPromocaoEntity>();
            CreateMap<HistoricoUsoPromocaoEntity, HistoricoUsoPromocao>().ConstructUsing(p => new HistoricoUsoPromocao(p.idPromocao, p.idCliente, p.utilizado));
            CreateMap<HistoricoUsoPromocaoDTO, HistoricoUsoPromocao>().ConstructUsing(p => new HistoricoUsoPromocao(p.IdPromocao, p.IdCliente, p.Utilizado));
        }
    }
}
