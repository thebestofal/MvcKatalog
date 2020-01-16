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
        [Required]
        public string Nazwa { get; set; }
        public string KrajPochodzenia { get; set; }

        public virtual ICollection<Piwo> Piwa { get; set; }
    }
}
