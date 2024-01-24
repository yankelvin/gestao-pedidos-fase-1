using AutoMapper;
using Service.DrivenAdapters.DataBaseAdapters.Entities.Clientes;
using Service.DrivingAdapters.RestAdapters.DTOs.Cliente;

namespace Service.DrivingAdapters.RestAdapters.DTOs.Mappings;

public class ClienteMappingProfile : Profile 
{
    public ClienteMappingProfile()
    {
        CreateMap<Domain.Models.Clientes.Cliente, CadastroClienteDto>();
        CreateMap<CadastroClienteDto, Domain.Models.Clientes.Cliente>();

        CreateMap<Domain.Models.Clientes.Cliente, ClienteDTO>();
        CreateMap<ClienteDTO, Domain.Models.Clientes.Cliente>();
        
        CreateMap<AtualizarClienteDTO, Domain.Models.Clientes.Cliente>();
        CreateMap<Domain.Models.Clientes.Cliente, AtualizarClienteDTO>();
        
        CreateMap<ClienteEntity, Domain.Models.Clientes.Cliente>().ReverseMap();
    }
}