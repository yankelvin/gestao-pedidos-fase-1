using AutoMapper;
using Domain.Models.Promocoes;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes;

namespace Service.DrivingAdapters.RestAdapters.DTOs.Mappings
{
    public class PromocaoMappingProfile : Profile
    {
        public PromocaoMappingProfile()
        {
            CreateMap<ItemPromocao, ItemPromocaoDTO>();
            CreateMap<HistoricoUsoPromocao, HistoricoUsoPromocaoDTO>();

            CreateMap<Promocao, PromocaoDTO>();
            CreateMap<Promocao, PromocaoEntity>();
            CreateMap<PromocaoEntity, Promocao>().ConstructUsing(p => new Promocao(p.Id, p.Texto, p.Status));
            CreateMap<PromocaoDTO, Promocao>().ConstructUsing(p => new Promocao(p.Texto, p.Status));
        }
    }
}
