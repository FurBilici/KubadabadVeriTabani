using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kubadabad.Models.ViewModels
{
    public class BuluntuVM
    {
        public Buluntular Buluntular { get; set; }
        public IEnumerable<SelectListItem> AçmaList { get; set; }
    }
}
