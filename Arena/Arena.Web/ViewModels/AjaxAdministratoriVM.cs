using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Arena.Web.ViewModels
{
    public class AjaxAdministratoriVM 
    {
        public List<admins> admini { get; set; }

        public class admins
        {
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Username { get; set; }
        }
    }
}