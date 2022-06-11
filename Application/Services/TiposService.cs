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
    public class TiposService
    {
        private readonly TipoRepository _tipoRepository;

        public TiposService(PokedexContext context)
        {
            _tipoRepository = new(context);
        }
        public async Task<List<TipoViewModel>> GetAllTiposViewModels()
        {
            var TipoList =  await _tipoRepository.GetAllTiposAsync();
            return TipoList.Select(tipo => new TipoViewModel
            {
                ID = tipo.ID,
                Nombre = tipo.Nombre    
            }).ToList();
        }
        public async Task<SaveTipoViewModel> GetByIdViewModels(int id)
        {
            var tipo = await _tipoRepository.GetByIdTiposAsync(id);
            
            SaveTipoViewModel saveTipoView = new();
            saveTipoView.ID = tipo.ID;
            saveTipoView.Nombre = tipo.Nombre;
            return saveTipoView;
        }

        public async Task CreateTiposViewModels(SaveTipoViewModel tipoViewModel)
        {
            Tipos tipos = new();
            tipos.Nombre = tipoViewModel.Nombre;
            await _tipoRepository.AddTiposAsync(tipos);
        }
        public async Task EditTiposViewModels(SaveTipoViewModel tipoViewModel)
        {
            Tipos tipos = new();
            tipos.ID = tipoViewModel.ID;
            tipos.Nombre = tipoViewModel.Nombre;
            await _tipoRepository.UpdateTiposAsync(tipos);
        }
        public async Task DeleteTiposViewModels(int id)
        {
            var tipos = await _tipoRepository.GetByIdTiposAsync(id);
            await _tipoRepository.DeleteTiposAsync(tipos);
        }
    }
}
