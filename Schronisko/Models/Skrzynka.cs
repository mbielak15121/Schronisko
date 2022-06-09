using System.ComponentModel.DataAnnotations;

namespace Schronisko.Models
{
    public class Skrzynka
    {
        [Key]
        public int Id { get; set; }

        public string Nadawca { get; set; }
        public string Odbiorca { get; set; }
        public string Tresc { get; set; }



    }
}
