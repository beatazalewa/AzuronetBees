using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AzuronetBees.Web.Models
{
    public class Beehive
    {
        [Key]
        public int BeehiveId { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę ula")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Nazwa ula:")]
        public string BeehiveName { get; set; }

        [Required(ErrorMessage = "Proszę dodać opis ula")]
        [StringLength(200, MinimumLength = 1)]
        [Display(Name = "Opis:")]
        public string Description { get; set; }

        [StringLength(50, MinimumLength = 4)]
        [Display(Name = "Lokalizacja:")]
        public string Location { get; set; }

        public virtual ICollection<Bee> Bees { get; set; }
    }
}

