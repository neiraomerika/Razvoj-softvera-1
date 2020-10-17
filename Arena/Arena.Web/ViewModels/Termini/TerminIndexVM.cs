using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels.Termini
{
    public class TerminIndexVM
    {
        public int Id { get; set; }
        public string NazivDvorane { get; set; }
        public DateTime Datum { get; set; }
        public decimal Cijena { get; set; }
    }
}
