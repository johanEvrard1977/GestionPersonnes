using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionPersonne.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionPersonne.Dal.DbContexts
{
    public class Context : DbContext
    {
        public DbSet<Personne> Personne { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Personne>().HasKey("Id");
            builder.Entity<Personne>().Property(u => u.Nom).IsRequired();
            builder.Entity<Personne>().Property(u => u.Prenom).IsRequired();
            base.OnModelCreating(builder);
        }
    }
}
