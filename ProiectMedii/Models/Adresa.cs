namespace ProiectMedii.Models
{
    public class Adresa
    {
        public int ID { get; set; }
        public string? Strada { get; set; }
        public int? Numar { get; set; }
        public string? Oras { get; set; }
        public string? Judet { get; set; }

        public ICollection<Restaurant>? Restaurante { get; set; }
        public ICollection<Recenzie>? Recenzii { get; set; }
        public ICollection<Rezervare>? Rezervari { get; set; }
    }
}
