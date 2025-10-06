using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rastro.Domain.DTOs.ContasAPagar;
using Rastro.Domain.Entities;

namespace Rastro.Domain.Interfaces.Service
{
    public interface IContasAPagarService
    {
        Task<ContasAPagar> CreateAsync(CreateContasAPagarDTO createDTO);
        Task<IEnumerable<ContasAPagar>> GetAllByUsuarioIdAsync(Guid usuarioId);
    }
}
