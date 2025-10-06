using AutoMapper;
using Rastro.Domain.DTOs.ContasAPagar;
using Rastro.Domain.DTOs.Usuario;
using Rastro.Domain.Entities;

namespace Rastro.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<ContasAPagar, CreateContasAPagarDTO>()
                .ReverseMap();

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}