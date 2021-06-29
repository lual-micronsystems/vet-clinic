using System.Collections.Generic;
using vet_clinic.Application.Pets.Queries.GetPets;

namespace vet_clinic.Application.Visits.Queries.GetVisits
{
    public class VisitsVm
    {
        public IList<VisitDto> Visits { get; set; }
    }
}
