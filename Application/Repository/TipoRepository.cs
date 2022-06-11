using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class TipoRepository
    {
        private readonly PokedexContext _context;
        
        public TipoRepository(PokedexContext context)
        {
            _context = context;
        }
        public async Task<List<Tipos>> GetAllTiposAsync()
        {

            return await _context.Set<Tipos>().ToListAsync();
        }
        public async Task<Tipos> GetByIdTiposAsync(int id)
        {
            return await _context.Set<Tipos>().FindAsync(id);
        }
        public async Task AddTiposAsync(Tipos tipos)
        {
            await _context.AddAsync(tipos);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTiposAsync(Tipos tipos)
        {
            _context.Entry(tipos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTiposAsync(Tipos tipos)
        {
            _context.Set<Tipos>().Remove(tipos);
            await _context.SaveChangesAsync();
        }
    }
}
