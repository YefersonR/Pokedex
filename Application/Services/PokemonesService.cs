using Application.Repository;
using Application.ViewModels;
using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokemonesService
    {
        private readonly PokemonRepository _pokemonesRepository;
         
        public PokemonesService(PokedexContext pokemonescontext)
        {
            _pokemonesRepository = new(pokemonescontext);

        }
        public async Task<List<PokemonViewModel>> GetAllPokemonViewModels()
        {
            var PokemonsList = await _pokemonesRepository.GetAllPokemonAsync();
            return PokemonsList.Select(pokemon => new PokemonViewModel
            {
                ID = pokemon.ID,
                Nombre =pokemon.Nombre,
                ImagenUrl =pokemon.ImagenUrl,
                Region=pokemon.Region,
                TipoPrimario = pokemon.TipoPrimario,
                TipoSecundario = pokemon.TipoSecundario
            }).ToList();
        }
        public async Task<SavePokemonViewModel> GetByIdPokemonViewModel(int id)
        {
            var pokemones = await _pokemonesRepository.GetByIdPokemonAsync(id);
            SavePokemonViewModel pokemonViewModel = new();
            pokemonViewModel.ID = pokemones.ID;
            pokemonViewModel.Nombre = pokemones.Nombre;
            pokemonViewModel.ImagenUrl= pokemones.ImagenUrl;
            pokemonViewModel.Region = pokemones.Region;
            return pokemonViewModel;

        }
        public async Task CreatePokemonViewModel(SavePokemonViewModel pokemonViewModel)
        {
            Pokemones pokemones = new();
       
            pokemones.Nombre = pokemonViewModel.Nombre;
            pokemones.ImagenUrl = pokemonViewModel.ImagenUrl;
            pokemones.Region= pokemonViewModel.Region;
            pokemones.TipoPrimario= pokemonViewModel.TipoPrimario;
            pokemones.TipoSecundario= pokemonViewModel.TipoSecundario;

            await _pokemonesRepository.AddPokemonAsync(pokemones);
        }

        public async Task UpdatePokemonViewModel(SavePokemonViewModel pokemonViewModel)
        {
            Pokemones pokemones = new();

            pokemones.ID = pokemonViewModel.ID;
            pokemones.Nombre = pokemonViewModel.Nombre;
            pokemones.ImagenUrl = pokemonViewModel.ImagenUrl;
            pokemones.Region = pokemonViewModel.Region;
            pokemones.TipoPrimario = pokemonViewModel.TipoPrimario;
            pokemones.TipoSecundario = pokemonViewModel.TipoSecundario;

            await _pokemonesRepository.AddPokemonAsync(pokemones);
        }
        public async Task DeletePokemonViewModel(int id)
        {
            var pokemones = await _pokemonesRepository.GetByIdPokemonAsync(id);
            await _pokemonesRepository.DeletePokemonAsync(pokemones);
        }
    }
}
