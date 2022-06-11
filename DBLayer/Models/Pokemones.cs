using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class Pokemones
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ImagenUrl { get; set; }
        public int Region { get; set; }
        public int TipoPrimario { get; set; }
        public int TipoSecundario { get; set; }

        public int IdRegion { get; set; }
        public int IdTipos { get; set; }

        public Regiones NavigationRegion { get; set; }
        public Tipos NavigationTipoPrimario { get; set; }
        public Tipos NavigationTipoSecundario { get; set; }
    }

}
