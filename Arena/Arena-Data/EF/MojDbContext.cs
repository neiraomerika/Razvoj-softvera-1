using Arena.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arena.EF
{

    public class MojDbContext : IdentityDbContext<Nalog>
    {
        public MojDbContext(DbContextOptions<MojDbContext> options) : base(options) { }

        public MojDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Nalog> Nalozi { get; set; }
        public DbSet<Plata> Plate { get; set; }
        public DbSet<Dvorana> Dvorana { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Termin> Termini { get; set; }
        public DbSet<TipUposlenika> TipoviUposlenika { get; set; }
        public DbSet<Uplata> Uplate { get; set; }
        public DbSet<Uposlenik> Uposlenici { get; set; }


        public async Task EnsureSeedData(MojDbContext context, UserManager<Nalog> userManager)
        {
            var admin = await userManager.FindByNameAsync("admin");
            if(admin == null)
            {

                var nalog = new Nalog
                {
                    UserName = "admin",
                    IsAdministrator = true,
                };

                await userManager.CreateAsync(nalog, "Password!1");

                context.Administratori.Add(new Administrator
                {
                    Ime = "Administrator",
                    Plata = new Plata
                    {
                        Iznos = 100
                    },
                    UserId = nalog.Id,
                    Prezime = "Admin"
                });
                context.SaveChanges();
            }


        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //app.fit.ba,1431
        //    optionsBuilder.UseSqlServer(@" Server=.; 
        //                                Database=ArenaBase; 
        //                                Trusted_Connection=False; 
        //                                MultipleActiveResultSets=true; 
        //                                User ID=Arena; 
        //                                Password=Arena2020");
        //}
    }
}
