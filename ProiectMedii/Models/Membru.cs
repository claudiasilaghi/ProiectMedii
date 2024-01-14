using System.ComponentModel.DataAnnotations;

namespace ProiectMedii.Models
{
    public class Membru
    {

        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau Ana-Maria")]
        [StringLength(30, MinimumLength = 3)]

        public string? Nume { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula (ex.Popescu sau Popescu Ionescu sau Popescu-Ionescu")]

        [StringLength(30, MinimumLength = 3)]

        public string? Prenume { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]

        public string? Telefon { get; set; }
        [Display(Name = "Nume")]
        public string? Numetot
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Rezervare>? Rezervari { get; set; }
    }
}
