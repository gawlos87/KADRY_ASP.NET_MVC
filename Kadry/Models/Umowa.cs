using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kadry.Models
{
    public class Umowa
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Uzupełnij pole rodzaj umowy")]
        [Display(Name="Rodzaj umowy")]
        public string RodzajUmowy { get; set; }

        public virtual ICollection<Pracownik> Pracownicy { get; set; }
    }
}