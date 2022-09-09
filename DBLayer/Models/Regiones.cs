using System.Collections.Generic;

namespace DBLayer.Models
{
    public class Regiones
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public ICollection<Pokemones> RegionPokemones { get; set; }

    }
}
