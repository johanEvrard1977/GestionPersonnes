using GestionPersonne.Core.Interfaces;
using GestionPersonne.Dal.DbContexts;
using GestionPersonne.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonne.Core.Repositories
{
    public class PersonneRepository : Repository<Guid, Personne>, IPersonneRepository
    {
        private readonly Context _context;
        public PersonneRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Personne>> Get(string Nom = null, string Prenom = null)
        {
            var request = from personnes in _context.Personne select personnes;
            if (Nom != null)
            {
                request = request
                    .Where(w => w.Nom.Equals(Nom))
                    .OrderBy(w => w.Nom);
            }
            else if (Prenom != null)
            {
                request = request
                    .Where(w => w.Prenom.Equals(Prenom))
                    .OrderBy(w => w.Prenom);
            }
            else
            {
                request = request
                    .OrderBy(w => w.Nom);
            }
            return await request
                .ToListAsync();
        }

        public async Task<IEnumerable<Personne>> GetByBegin(string Nom = null, string Prenom = null)
        {
            var request = from personnes in _context.Personne select personnes;
            if (Nom != null)
            {
                request = request
                    .Where(w => w.Nom.StartsWith(Nom))
                    .OrderBy(w => w.Nom);
            }
            else if (Prenom != null)
            {
                request = request
                    .Where(w => w.Prenom.StartsWith(Prenom))
                    .OrderBy(w => w.Prenom);
            }
            else
            {
                request = request
                    .OrderBy(w => w.Nom);
            }
            return await request
                .ToListAsync();
        }

        public async Task<IEnumerable<Personne>> GetByEnd(string Nom = null, string Prenom = null)
        {
            var request = from personnes in _context.Personne select personnes;
            if (Nom != null)
            {
                request = request
                    .Where(w => w.Nom.EndsWith(Nom))
                    .OrderBy(w => w.Nom);
            }
            else if (Prenom != null)
            {
                request = request
                    .Where(w => w.Prenom.EndsWith(Prenom))
                    .OrderBy(w => w.Prenom);
            }
            return await request
                .ToListAsync();
        }
    }
}
