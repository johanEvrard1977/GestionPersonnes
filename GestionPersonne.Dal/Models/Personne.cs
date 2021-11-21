using System;

namespace GestionPersonne.Dal.Models
{
    public class Personne
    {
        public Guid Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
    }
}
