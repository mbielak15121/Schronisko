using System.ComponentModel.DataAnnotations;

namespace Schronisko.Models
{
    public class Ogloszenie
    {

        public int Id { get; set; }
        [Required]
        public string Gatunek { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Rasa { get; set; }
        [Required]
        public int Wiek { get; set; }
        [Required]
        public string Opis { get; set; }
        public string Zdjecie { get; set; }

    }
}
