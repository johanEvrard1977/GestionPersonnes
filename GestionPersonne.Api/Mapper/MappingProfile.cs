using AutoMapper;
using GestionPersonne.Api.Models;
using GestionPersonne.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonne.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Personne, PersonneApi>();

            // Resource to Domain
            CreateMap<PersonneApi, Personne>();
        }
    }
}
