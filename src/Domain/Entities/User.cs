using vet_clinic.Domain.Common;
using vet_clinic.Domain.Enums;
using vet_clinic.Domain.Events;
using System;
using System.Collections.Generic;

namespace vet_clinic.Domain.Entities
{
    public class User : AuditableEntity
    {
        public User()
        {
            Pets = new List<Pet>();
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

        public IList<Pet> Pets { get; private set; }
    }
}