using System;
using System.Collections.Generic;
using System.Text;

namespace Arena.Models
{
    public class Termin
    {
        public int ID { get; set; }

        public int DvoranaID { get; set; }
        public Dvorana Dvorana { get; set; }

        public DateTime DatumIVrijeme { get; set; }
        public decimal Cijena { get; set; }
    }
}
