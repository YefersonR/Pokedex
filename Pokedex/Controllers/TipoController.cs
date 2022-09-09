using Application.Services;
using Application.ViewModels;
using DBLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class TipoController : Controller
    {
        private readonly TiposService _tiposService;
        public TipoController(PokedexContext context)
        {
            _tiposService = new(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _tiposService.GetAllTiposViewModels());
        }
        public IActionResult Create()
        {
            return View("SaveTipo", new SaveTipoViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveTipoViewModel tipoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", tipoViewModel);
            }
            await _tiposService.CreateTiposViewModels(tipoViewModel);
            return RedirectToRoute(new {controller = "Tipo" , action = "Index"});
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveTipo",await _tiposService.GetByIdViewModels(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveTipoViewModel tipoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", tipoViewModel);
            }
            await _tiposService.EditTiposViewModels(tipoViewModel);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _tiposService.GetByIdViewModels(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _tiposService.DeleteTiposViewModels(id);
            return RedirectToRoute(new { controlle = "Tipo", action = "Index" });
        }

    }
}
