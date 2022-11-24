using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OEC222.Pizzeria.Web.Models
{
    public class CreatePizzaViewModel
    {
        [DisplayName("Codice")]
        [Required(ErrorMessage = "Il codice della pizza è obbligatorio")]
        [StringLength(3,ErrorMessage = "3 caratteri")]
        public string Code { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Il nome della pizza è obbligatorio")]
        public string Name { get; set; }

        [DisplayName("Prezzo")]
        [Range(2, 2000, ErrorMessage = "Prezzo pizza non valido")]
        public decimal Price { get; set; }


    }
}
