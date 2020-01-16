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
        
        [Required]
        public string Nazwa { get; set; }
        public string Typ { get; set; }

        [Range(1,100)]
        [Display(Name = "Zawartość alkoholu w %")]
        public double ZawartoscAlk { get; set; }

        public int Ibu { get; set; }

        [Display(Name = "Zawartość ekstraktu w %")]
        public double Ekstrakt { get; set; }
        [Required]
        public int BrowarId { get; set; }
        public virtual Browar Browar { get; set; }
    }
}
