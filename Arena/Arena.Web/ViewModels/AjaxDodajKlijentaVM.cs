using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels
{
    public class AjaxDodajKlijentaVM
    {
        public List<SelectListItem> gradovi { get; set; }
    }
}
