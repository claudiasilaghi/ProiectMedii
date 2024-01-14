namespace ProiectMedii.Models
{
    public class Recenzie
    {
        public int ID { get; set; }

        public string? Parere { get; set; }
        public int? AdresaID { get; set; }
        public Adresa? Adresa { get; set; }

        public int RestaurantID { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
