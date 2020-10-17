using Arena.EF;
using Arena.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.Extensions
{
    //Ekstenzija ciji je zadatak napraviti scope sa db i pozvati ekstenzijsku metodu nad contextom koja inicijalno kreira administratorski nalog
    public static class DatabaseSeedInitializer
    {

        public static void EnsureDatabaseIsSeeded(this IApplicationBuilder applicationBuilder,
          UserManager<Nalog> userManager)
        {


            // seed the database using an extension method
            using (var serviceScope = applicationBuilder.ApplicationServices
           .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MojDbContext>();
                context.EnsureSeedData(context, userManager).Wait();
            }
        }
    }
}
