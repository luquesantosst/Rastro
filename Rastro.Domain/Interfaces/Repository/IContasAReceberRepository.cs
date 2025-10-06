using Rastro.Domain.Entities;
using Rastro.Domain.Entities.Enums;

namespace Rastro.Domain.Interfaces.Repository
{
    public interface IContasAReceberRepository
    {
        Task<ContasAReceber> CreateAsync(ContasAReceber contasAReceber);
        Task<ContasAReceber> GetByIdAsync(Guid id);
        Task<IEnumerable<ContasAReceber>> GetAllAsync();
        Task<ContasAReceber> UpdateAsync(ContasAReceber contasAReceber);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ContasAReceber>> GetByVencimentoAsync(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<ContasAReceber>> GetByStatusAsync(StatusConta status);
        Task<bool> ExistsAsync(Guid id);
    }
}