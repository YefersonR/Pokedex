using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PokemonRepository
    {
        private readonly PokedexContext _context;

        public PokemonRepository(PokedexContext context)
        {
            _context = context;
        }

        public async Task<List<Pokemones>> GetAllPokemonAsync()
        {
            return await _context.Set<Pokemones>().ToListAsync();
        }

        public async Task<Pokemones> GetByIdPokemonAsync(int id)
        {
            return await _context.Set<Pokemones>().FindAsync(id);
        }

        public async Task AddPokemonAsync(Pokemones pokemon)
        {
            await _context.AddAsync(pokemon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePokemonAsync(Pokemones pokemon)
        {
            _context.Entry(pokemon).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }

        public async Task DeletePokemonAsync(Pokemones pokemon)
        {
            _context.Set<Pokemones>().Remove(pokemon);
            await _context.SaveChangesAsync();
        }

    }
}
