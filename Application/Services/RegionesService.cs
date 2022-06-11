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
    public class RegionesService
    {
        public readonly RegionRepository _regionRepository;

        public RegionesService(PokedexContext context)
        {
            _regionRepository = new(context);
        }
        public async Task<List<RegionViewModel>> GetAllRegionViewModels()
        {
            var ListRegiones = await _regionRepository.GetAllRegionesAsync();
            return ListRegiones.Select(region => new RegionViewModel
            {
                ID = region.ID,
                Nombre = region.Nombre
            }).ToList();
        }
        public async Task<SaveRegionViewModel> GetByIdRegionViewModel(int id)
        {
            var region = await _regionRepository.GetByIdRegionesAsync(id);
            SaveRegionViewModel saveRegionView = new();
            saveRegionView.ID = region.ID;
            saveRegionView.Nombre = region.Nombre;
            return saveRegionView;
        }
        public async Task CreateRegionViewModel(SaveRegionViewModel regionViewModel)
        {
            Regiones regiones = new();
            regiones.Nombre = regionViewModel.Nombre;
            await _regionRepository.AddRegionesAsync(regiones);
        }
        public async Task UpdateRegionViewModel(SaveRegionViewModel regionViewModel)
        {
            Regiones regiones = new();
            regiones.ID = regionViewModel.ID;
            regiones.Nombre = regionViewModel.Nombre;
            await _regionRepository.UpdateRegionesAsync(regiones);
        }
        public async Task DeleteRegionViewModel(int id)
        {
            var regiones = await _regionRepository.GetByIdRegionesAsync(id);
            await _regionRepository.DeleteRegionesAsync(regiones);
        }
    }
}
