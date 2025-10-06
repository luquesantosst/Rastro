using Rastro.Domain.Entities;
using Rastro.Domain.Entities.Enums;

namespace Rastro.Domain.Interfaces.Repository
{
    public interface IContasAPagarRepository
    {
        Task CreateAsync(ContasAPagar contaAPagar);
        Task<ContasAPagar> GetByIdAsync(Guid id);
        Task<IEnumerable<ContasAPagar>> GetAllAsync();
        Task<ContasAPagar> UpdateAsync(ContasAPagar contaAPagar);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ContasAPagar>> GetByVencimentoAsync(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<ContasAPagar>> GetByStatusAsync(StatusConta status);
        Task<bool> ExistsAsync(Guid id);
        Task<IEnumerable<ContasAPagar>> GetByUsuarioIdAsync(Guid usuarioId);
        Task<IEnumerable<ContasAPagar>> GetByUsuarioEStatusAsync(Guid usuarioId, StatusConta status);
    }
}