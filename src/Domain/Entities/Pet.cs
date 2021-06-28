using vet_clinic.Domain.Common;
using vet_clinic.Domain.Enums;
using vet_clinic.Domain.Events;
using System;
using System.Collections.Generic;

namespace vet_clinic.Domain.Entities
{
    public class Pet : AuditableEntity
    {
        public Pet()
        {
            Visits = new List<Visit>();
        }

        public int Id { get; set; }
        public string PetName { get; set; }
        public int PetType { get; set; }
        public string Breed { get; set; }
        public DateTime? BirthDate { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public IList<Visit> Visits { get; private set; }
    }
}