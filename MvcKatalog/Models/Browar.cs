using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProj.Models
{
    public class Browar
    {
        public int Id { get; set; }
        [DisplayName("Nazwa Browaru")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nazwa browaru nie może być puste")]
        public string Nazwa { get; set; }
        [DisplayName("Kraj pochodzenia")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole kraj pochodzenia nie może być puste")]
        public string KrajPochodzenia { get; set; }

        public virtual ICollection<Piwo> Piwa { get; set; }
    }
}
