using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveTipoViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Debe añadir un tipo")]
        public string Nombre { get; set; }
    }
}
