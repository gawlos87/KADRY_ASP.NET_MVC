using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kadry.Models
{
    public class Pracownik
    {
        public int Id { get; set; }
        [Display(Name ="Dział")]
        public int DziałId { get; set; }
        [Display(Name ="Rodzaj umowy")]
        public int UmowaId { get; set; }
        [Required(ErrorMessage ="Uzupełnij pole imię")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Uzupełnij pole nazwisko")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Uzupełnij pole stanowisko")]
        public string Stanowisko { get; set; }

        [MaxLength(100,ErrorMessage ="Maksymalna długość - 100 znaków")]
        [Display(Name ="Opis stanowiska")]
        public string OpisStanowiska { get; set; }

        public virtual Dział Działy { get; set; }
        public virtual Umowa Umowy { get; set; }

    }
}