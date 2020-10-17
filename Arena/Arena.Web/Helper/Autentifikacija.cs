using Arena.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.Helper
{
    public enum TipKorisnika
    {
        Administrator=1,
        Uposlenik,
        Klijent
    }
    public class Autentifikacija
    {
        private const string _logiraniNalog = "logirani_nalog";
        private  IHttpContextAccessor httpContextAccessor;


        public Autentifikacija(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public static void PokreniNovuSesiju(Nalog nalog,HttpContext httpContext)
        {
            httpContext.Session.Set(_logiraniNalog, nalog);
        }

        public static void OcistiSesiju(HttpContext httpContext)
        {
            httpContext.Session.Set(_logiraniNalog, null);
        }

        public static Nalog GetLogiraniNalog( HttpContext httpContext)
        {
            Nalog nalog = httpContext.Session.Get<Nalog>(_logiraniNalog);
            if(nalog==null)
            {
                return nalog;
            }
            PokreniNovuSesiju(nalog, httpContext);
            return nalog;
        }
    }
}
