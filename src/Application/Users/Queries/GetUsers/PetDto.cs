using System;
using AutoMapper;
using vet_clinic.Application.Common.Mappings;
using vet_clinic.Domain.Entities;

namespace vet_clinic.Application.Users.Queries.GetUsers
{
    public class PetDto : IMapFrom<Pet>
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public int PetType { get; set; }
        public string Breed { get; set; }
        public DateTime? BirthDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pet, PetDto>()
                .ForMember(d => d.PetName, opt => opt.MapFrom(s => s.PetName));
        }
    }
}
