using GestionPersonne.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonne.Core.Interfaces
{
    public interface IPersonneRepository : IRepository<Guid, Personne>
    {
        Task<IEnumerable<Personne>> Get(string Name = null, string Prenom = null);
        Task<IEnumerable<Personne>> GetByBegin(string Name = null, string Prenom = null);
        Task<IEnumerable<Personne>> GetByEnd(string Name = null, string Prenom = null);
    }
}
