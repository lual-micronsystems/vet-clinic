using vet_clinic.Application.Common.Mappings;
using vet_clinic.Domain.Entities;
using System.Collections.Generic;

namespace vet_clinic.Application.Users.Queries.GetUsers
{
    public class UserDto : IMapFrom<User>
    {
        public UserDto()
        {
            Pets = new List<PetDto>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public int? Active { get; set; }

        public IList<PetDto> Pets { get; set; }
    }
}
