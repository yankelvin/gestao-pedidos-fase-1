using AutoMapper;
using Domain.Models.Usuarios;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Usuarios;

namespace Service.DrivingAdapters.RestAdapters.DTOs.Mappings
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioEntity, Usuario>().ConstructUsing(p => new Usuario(p.Id, p.Nome, p.Email, p.Senha, p.Tipo, p.Ativo));
        }
    }
}
