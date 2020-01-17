using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProj.Models
{
    public class Piwo
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nazwa nie może być puste")]
        public string Nazwa { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole typ nie może być puste")]
        public string Typ { get; set; }

        [Range(0D,100D, ErrorMessage="Podaj wartość od 0 do 100")]
        //[RegularExpression(@"^\d[0-9]\.?[0-9]*$")]
        [Display(Name = "Alkohol w %")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole zawartość alkoholu nie może być puste")]
        public double ZawartoscAlk { get; set; }

        public int? Ibu { get; set; }

        [Display(Name = "Ekstrakt w %")]
        public double? Ekstrakt { get; set; }
        [Required]
        public int BrowarId { get; set; }
        public virtual Browar Browar { get; set; }
    }
}
