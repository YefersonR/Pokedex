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
    public class RegionController : Controller
    {
        private readonly RegionesService _regionesService;

        public RegionController(PokedexContext context)
        {
            _regionesService = new(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _regionesService.GetAllRegionViewModels());
        }
        public IActionResult Create()
        {

            return View("SaveRegion", new SaveRegionViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveRegionViewModel regionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", regionViewModel);
            }
            await _regionesService.CreateRegionViewModel(regionViewModel);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveRegion", await _regionesService.GetByIdRegionViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegionViewModel regionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", regionViewModel);
            }
            await _regionesService.UpdateRegionViewModel(regionViewModel);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _regionesService.GetByIdRegionViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _regionesService.DeleteRegionViewModel(id);
            return RedirectToRoute(new { controlle = "Region", action = "Index" });
        }
    }
}
