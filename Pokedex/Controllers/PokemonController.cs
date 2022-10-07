using Application.Services;
using Application.ViewModels;
using DBLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonesService _pokemonesservice;
        private readonly RegionesService _regionesservice;
        private readonly TiposService _tiposservice;

        public PokemonController(PokedexContext context)
        {
            _pokemonesservice = new(context);
            _regionesservice = new(context);
            _tiposservice = new(context);

        }
        public async Task<IActionResult> Index()
        {
            return View(await _pokemonesservice.GetAllPokemonViewModels());
        }

        public async Task<IActionResult> Create()
        {
            SavePokemonViewModel pokemonViewModel = new();
            pokemonViewModel.listregiones = await _regionesservice.GetAllRegionViewModels();
            pokemonViewModel.listtipos = await _tiposservice.GetAllTiposViewModels();
            return View("SavePokemon", pokemonViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel pokemonViewModel)
        {

            pokemonViewModel.listregiones = await _regionesservice.GetAllRegionViewModels();
            pokemonViewModel.listtipos = await _tiposservice.GetAllTiposViewModels();
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", pokemonViewModel);
            }
             
            await _pokemonesservice.CreatePokemonViewModel(pokemonViewModel);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var pokemon = await _pokemonesservice.GetByIdPokemonViewModel(id);
            pokemon.listregiones = await _regionesservice.GetAllRegionViewModels();
            pokemon.listtipos = await _tiposservice.GetAllTiposViewModels();
        

            return View("SavePokemon",pokemon);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel pokemonViewModel)
        {
         
            pokemonViewModel.listregiones = await _regionesservice.GetAllRegionViewModels();
            pokemonViewModel.listtipos = await _tiposservice.GetAllTiposViewModels();
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", pokemonViewModel);
            }
            await _pokemonesservice.UpdatePokemonViewModel(pokemonViewModel);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pokemonesservice.GetByIdPokemonViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonesservice.DeletePokemonViewModel(id);
            return RedirectToRoute(new { controlle = "Region", action = "Index" });
        }

    }
}
