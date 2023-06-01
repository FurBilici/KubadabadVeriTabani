using Kubadabad.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kubadabad.Models.ViewModels
{
    public class RaporVM
    {
        public AçmaRapor AçmaRapor { get; set; }
        public IEnumerable<SelectListItem> AçmaList { get; set; }
    }
}
