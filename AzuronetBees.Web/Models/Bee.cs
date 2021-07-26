using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzuronetBees.Web.Models
{
    public class Bee
    {
        [Key]
        public int BeeId { get; set; }

        [Required(ErrorMessage = "Proszę wybrać rasę pszczoły")]
        [Display(Name = "Rasa pszczół:")]
        public BreedOfBees? BreedOfBees { get; set; }

        [Required(ErrorMessage = "Proszę wpisz opis rodziny")]
        [Display(Name = "Opis:")]
        public string Description { get; set; }

        [Display(Name = "Rojliwość:")]
        public bool SwarmingBees { get; set; }

        [Display(Name = "Aktualna:")]
        public bool Active { get; set; }

        [Range(1, 10)]
        [Required(ErrorMessage = "Proszę ocenić całokształt rodziny")]
        [Display(Name = "Ocena ogólna:")]
        public int? Overall { get; set; }

        [NotMapped]
        [Display(Name = "Zdjęcie pszczoły:")]
        public IFormFile PhotoAvatar { get; set; }

        public string ImageName { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        [Display(Name = "Ul:")]
        public int? BeehiveId { get; set; }

        public virtual Beehive Beehive { get; set; }
    }
}
