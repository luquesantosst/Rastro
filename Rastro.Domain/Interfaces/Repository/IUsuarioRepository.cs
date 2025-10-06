using Rastro.Domain.DTOs.Usuario;
using Rastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rastro.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> CreateAsync(Usuario Usuario);
        Task<Usuario> GetByIdAsync(Guid id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> UpdateAsync(Usuario Usuario);
        Task DeleteAsync(Guid id);
    }
}
