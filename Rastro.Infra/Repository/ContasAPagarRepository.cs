using Rastro.Domain.Entities;
using Rastro.Domain.Entities.Enums;
using Rastro.Domain.Interfaces.Repository;
using Rastro.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rastro.Infra.Repository
{
    public class ContasAPagarRepository : IContasAPagarRepository
    {
        private readonly AppDbContext _context;

        public ContasAPagarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ContasAPagar contaAPagar)
        {
            await _context.ContasAPagar.AddAsync(contaAPagar);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContasAPagar>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ContasAPagar> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContasAPagar>> GetByStatusAsync(StatusConta status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContasAPagar>> GetByUsuarioEStatusAsync(Guid usuarioId, StatusConta status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContasAPagar>> GetByUsuarioIdAsync(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContasAPagar>> GetByVencimentoAsync(DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        public Task<ContasAPagar> UpdateAsync(ContasAPagar contaAPagar)
        {
            throw new NotImplementedException();
        }
    }
}
