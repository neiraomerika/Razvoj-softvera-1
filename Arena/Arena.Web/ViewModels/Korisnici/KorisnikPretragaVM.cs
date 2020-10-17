using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels.Korisnici
{
    public class KorisnikPretragaVM
    {
        public string Username { get; set; }

        public List<KorisnikIndexVM> RezultatPretrage { get; set; }
    }
}
