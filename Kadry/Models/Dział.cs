using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kadry.Models
{
    public class Dział
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Uzupełnij pole nazwa dzialu")]
        [Display(Name ="Nazwa działu")]
        public string NazwaDziału { get; set; }

        public virtual ICollection<Pracownik> Pracownicy { get; set; }
    }
}