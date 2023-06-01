using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kubadabad.Models
{
    public class AçmaRapor
    {
        [Key]
        public int RaporId { get; set; }
        [Required]
        [Display(Name = "Rapor")]
        public string RaporDetay { get; set; }
        [Display(Name = "Tarih")]
        public DateTime RaporTarih { get; set; }

        [Display(Name = "Açma Sorumlusu")]
        public string RaporYazar { get; set; }
        [Display(Name = "Açma Açılış Kotu")]
        public string AçılışKotu { get; set; }
        [Display(Name = "Açma Kapanış Kotu")]
        public string KapanışKotu { get; set; }
        public string AçmaÜçBoyut { get; set; }

        public int AçmaListesiID { get; set; }
        public AçmaListesi AçmaListesi { get; set; }
    }
}
