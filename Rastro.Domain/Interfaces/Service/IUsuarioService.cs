using Rastro.Domain.DTOs.Usuario;

namespace Rastro.Domain.Interfaces.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> CreateAsync(UsuarioDTO createDTO);
        Task Update(UsuarioDTO updateDTO);

        Task<UsuarioDTO> GetByIdAsync(Guid id);
    }
}