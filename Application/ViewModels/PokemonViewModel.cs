using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PokemonViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ImagenUrl { get; set; }
        public int Region { get; set; }
        public int TipoPrimario { get; set; }
        public int TipoSecundario { get; set; }

    }
}
