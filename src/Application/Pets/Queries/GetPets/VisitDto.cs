using System;
using AutoMapper;
using vet_clinic.Application.Common.Mappings;
using vet_clinic.Domain.Entities;

namespace vet_clinic.Application.Pets.Queries.GetPets
{
    public class VisitDto : IMapFrom<Visit>
    {
        public int Id { get; set; }
        public int VisitType { get; set; }
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; }
        public int PetId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Visit, VisitDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
