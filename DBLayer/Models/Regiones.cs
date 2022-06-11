using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class Regiones
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public ICollection<Pokemones> RegionPokemones { get; set; }

    }
}
