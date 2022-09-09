using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SaveRegionViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Debe añadir el nombre de la region")]
        public string Nombre { get; set; }
    }
}
