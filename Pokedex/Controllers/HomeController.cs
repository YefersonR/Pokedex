using Application.Services;
using Application.ViewModels;
using DBLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonesService _pokemonesService;
        private readonly RegionesService _regionesService;
        private readonly TiposService _tiposService;

        public HomeController(PokedexContext context)
        {
            _pokemonesService = new(context);
            _regionesService = new(context);
            _tiposService = new(context);
        }

        public async Task<IActionResult> Index()
        {
            var regiones = await _regionesService.GetAllRegionViewModels();
            var tipos = await _tiposService.GetAllTiposViewModels();
            var pokemones = await _pokemonesService.GetAllPokemonViewModels();
            ListViewModels list= new();
            list.ListPokemones = pokemones;
            list.Regiones = regiones;
            list.Tipos = tipos;

            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string pokemon, List<int> region)
        {
            var regiones = await _regionesService.GetAllRegionViewModels();
            var tipos = await _tiposService.GetAllTiposViewModels();
            var pokemones = await _pokemonesService.GetAllPokemonViewModels();
            var filterPokemones = new List<PokemonViewModel>();

            if (pokemon != null)
            {
                filterPokemones = pokemones.Where(pokemone => pokemone.Nombre.ToLower().Contains(pokemon.ToLower())).ToList();

            }
            else if(region != null)
            {
                filterPokemones = pokemones.Where(pok => region.Contains(pok.Region)).ToList();
            }

            ListViewModels list = new();
            list.ListPokemones = filterPokemones;
            list.Regiones = regiones;
            list.Tipos = tipos;


            return View(list);
        }
    }
}
