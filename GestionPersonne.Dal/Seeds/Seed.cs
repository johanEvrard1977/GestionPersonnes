using GestionPersonne.Dal.DbContexts;
using GestionPersonne.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonne.Dal.Seeds
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<Context>();
            context.Database.EnsureCreated();



            if (!context.Personne.Any())
            {
                Personne one = new Personne();

                one.Nom = "Evrard";
                one.Prenom = "Johan";
                context.Personne.Add(one);
                context.Entry(one).State = EntityState.Added;

                Personne two = new Personne();

                two.Nom = "De Warzée";
                two.Prenom = "Gérome";
                context.Personne.Add(two);
                context.Entry(two).State = EntityState.Added;

                Personne three = new Personne();

                three.Nom = "Goldman";
                three.Prenom = "Jean-Jacques";
                context.Personne.Add(three);
                context.Entry(three).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
