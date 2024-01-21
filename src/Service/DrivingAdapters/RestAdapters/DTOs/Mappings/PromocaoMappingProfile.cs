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
            CreateMap<ItemPromocao, ItemPromocaoDTO>();
            CreateMap<HistoricoUsoPromocao, HistoricoUsoPromocaoDTO>();
            CreateMap<PromocaoEntity, Promocao>().ConstructUsing(p => new Promocao(p.Id, p.Texto, p.Status));
        }
    }
}
