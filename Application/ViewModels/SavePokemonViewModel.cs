using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SavePokemonViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Debe ingresar el nombre del pokemon")]        
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe agregar una imagen del pokemon")]
        public string ImagenUrl { get; set; }
        [Required(ErrorMessage = "Debe añadir una region")]
        public int Region { get; set; }
        [Required(ErrorMessage = "Debe establecer un tipo para el pokemon")]
        public int TipoPrimario { get; set; }
        public int TipoSecundario { get; set; }

    }
}
