using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arena.Models
{
    public class Nalog : IdentityUser
    {
        public bool IsAdministrator { get; set; }
        public bool IsUposlenik { get; set; }
        public bool IsKlijent { get; set; }
    }
}
