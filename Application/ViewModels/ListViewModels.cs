using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ListViewModels
    {
        public SavePokemonViewModel Pokemones = new();
        public List<RegionViewModel> Regiones = new();
        public List<TipoViewModel> Tipos =new();
        public List<PokemonViewModel> ListPokemones = new();
    }
}
