using AutoMapper;
using Rastro.API.Controllers.ViewModel.Request;
using Rastro.Domain.DTOs.Usuario;

namespace Rastro.API.Mappings
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<UsuarioRegistroViewModel, UsuarioDTO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}