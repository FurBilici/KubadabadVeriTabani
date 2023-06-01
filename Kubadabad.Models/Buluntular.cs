using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kubadabad.Models
{
    public class Buluntular
    {
        [Key]
        public int BuluntuId { get; set; }

        [Required]
        [Display(Name = "Buluntu Türü")]
        public string BuluntuTürü { get; set; }

        [Display(Name = "Buluntu Tarihi")]
        public DateTime BuluntuTarih { get; set; }

        [Display(Name = "Buluntu Dönemi")]
        public string Evre { get; set; }

        [Display(Name = "Buluntu Kotu")]
        public string BuluntuKotu { get; set; }

        [Display(Name = "X-Y Koordinatları")]
        public string XveY { get; set; }

        [Display(Name = "Malzeme")]
        public string Malzeme { get; set; }

        [Display(Name = "Durumu")]
        public string BuluntuDurumu { get; set; }

        [Display(Name = "Buluntu Envanterlik Mi?")]
        public bool Envanterlik { get; set; }

        [Display(Name = "3D")]
        public string ÜçBoyut { get; set; }

        public int AçmaListesiID { get; set; }
        public AçmaListesi AçmaListesi { get; set; }
    }
}
