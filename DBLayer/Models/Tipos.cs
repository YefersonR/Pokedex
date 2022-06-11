using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class Tipos
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public ICollection<Pokemones> TiposPokemones { get; set; }
        public ICollection<Pokemones> TiposPokemonesSecundarios { get; set; }

    }
}
