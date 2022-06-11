using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class RegionRepository
    {
        private readonly PokedexContext _context;

        public RegionRepository(PokedexContext context)
        {
            _context = context;
        }
        public async Task<List<Regiones>> GetAllRegionesAsync()
        {
            return await _context.Set<Regiones>().ToListAsync();
        }

        public async Task<Regiones> GetByIdRegionesAsync(int id)
        {
            return await _context.Set<Regiones>().FindAsync(id);
        }
        public async Task AddRegionesAsync(Regiones regiones)
        {
            await _context.AddAsync(regiones);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRegionesAsync(Regiones regiones)
        {
            _context.Entry(regiones).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRegionesAsync(Regiones regiones)
        {
            _context.Set<Regiones>().Remove(regiones);
            await _context.SaveChangesAsync();
        }
    }
}
