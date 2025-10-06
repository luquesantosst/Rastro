using Microsoft.EntityFrameworkCore;
using Rastro.Domain.Entities;
using Rastro.Domain.Interfaces.Repository;
using Rastro.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rastro.Infra.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateAsync(Usuario Usuario)
        {
            await _context.Usuario.AddAsync(Usuario);
            await _context.SaveChangesAsync();
            return Usuario;
        }

        public async Task DeleteAsync(Guid id)
        {
            _context.Usuario.Remove(_context.Usuario.Find(id));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await _context.Usuario.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<Usuario> UpdateAsync(Usuario Usuario)
        {
            _context.Usuario.Update(Usuario);
            _context.SaveChangesAsync();
            return Task.FromResult(Usuario);
        }
    }
}
