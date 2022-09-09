using System.Collections.Generic;

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
