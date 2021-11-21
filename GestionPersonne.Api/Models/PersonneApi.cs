using System;
using System.ComponentModel.DataAnnotations;

namespace GestionPersonne.Api.Models
{
    public class PersonneApi
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Le prénom est recquit")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Le nom est recquit")]
        public string Nom { get; set; }
    }
}
