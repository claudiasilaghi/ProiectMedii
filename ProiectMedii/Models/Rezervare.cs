using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectMedii.Models
{
    public class Rezervare
    {
        public int ID { get; set; }


        [Range(1, 8, ErrorMessage = "Numarul maxim de persoane permise pentru o rezervare este 8!")]
        public int? Persoane { get; set; }
        public DateTime Data { get; set; }
        public int RestaurantID { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int? AdresaID { get; set; }
        public Adresa? Adresa { get; set; }
        public int MembruID { get; set; }
        public Membru? Membru { get; set; }
    }
}
