using AutoMapper;
using Service.DrivenAdapters.DataBaseAdapters.Entities.Clientes;
using Service.DrivenAdapters.DataBaseAdapters.Entities.Pedidos;
using Service.DrivingAdapters.RestAdapters.DTOs.Cliente;
using Service.DrivingAdapters.RestAdapters.DTOs.Pedido;

namespace Service.DrivingAdapters.RestAdapters.DTOs.Mappings;

public class PedidoMappingProfile : Profile 
{
    public PedidoMappingProfile()
    {
        CreateMap<Domain.Models.Pedidos.Pedido, PedidoEntity>().ReverseMap();
        
        CreateMap<Domain.Models.Pedidos.Pedido, PedidoDTO>().ReverseMap();
        CreateMap<Domain.Models.Pedidos.Pedido, CadastroPedidoDto>().ReverseMap();
    }
}