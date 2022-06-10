using System.ComponentModel.DataAnnotations;

namespace Schronisko.Models
{
    public class Harmonogram
    {
        public int Id { get; set; }
        [Required]
        public int Dni { get; set; }
        [Required]
        public string Godziny { get; set; }
        [Required]
        public string ZakresObowiazkow { get; set; }
        
    }
}
