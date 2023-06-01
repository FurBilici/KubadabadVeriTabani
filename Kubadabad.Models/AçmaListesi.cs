using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kubadabad.Models
{
    public class AçmaListesi
    {
        [Key]
        public int Id { get; set; }
        public string AçmaAdı { get; set; }
        public bool AçmaAçıkMı { get; set; }
    }
}
