using vet_clinic.Application.Common.Mappings;
using vet_clinic.Domain.Entities;
using System.Collections.Generic;
using System;
using AutoMapper;

namespace vet_clinic.Application.Pets.Queries.GetPets
{
    public class PetDto : IMapFrom<Pet>
    {
        public PetDto()
        {
            Visits = new List<VisitDto>();
        }

        public int Id { get; set; }
        public string PetName { get; set; }
        public int PetType { get; set; }
        public string Breed { get; set; }
        public DateTime? BirthDate { get; set; }
        public int UserId { get; set; }

        public IList<VisitDto> Visits { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pet, PetDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
