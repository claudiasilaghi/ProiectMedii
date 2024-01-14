using System.ComponentModel.DataAnnotations;

namespace ProiectMedii.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string? Nume { get; set; }

        [Range(1, 5, ErrorMessage = "Ratingul maxim posibil este 5!")]
        public int? Rating { get; set; }
        public int AdresaID { get; set; }
        public Adresa? Adresa { get; set; }
        public ICollection<Rezervare>? Rezervari { get; set; }
        public ICollection<Recenzie>? Recenzii { get; set; }
    }
}
