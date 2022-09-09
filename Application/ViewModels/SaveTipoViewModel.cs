using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SaveTipoViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Debe añadir un tipo")]
        public string Nombre { get; set; }
    }
}
