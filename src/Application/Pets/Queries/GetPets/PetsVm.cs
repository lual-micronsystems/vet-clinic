using System.Collections.Generic;

namespace vet_clinic.Application.Pets.Queries.GetPets
{
    public class PetsVm
    {
        public IList<PetDto> Pets { get; set; }
    }
}
