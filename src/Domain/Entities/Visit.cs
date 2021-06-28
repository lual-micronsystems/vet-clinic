using vet_clinic.Domain.Common;
using vet_clinic.Domain.Enums;
using vet_clinic.Domain.Events;
using System;
using System.Collections.Generic;

namespace vet_clinic.Domain.Entities
{
    public class Visit : AuditableEntity
    {
        public int Id { get; set; }
        public int VisitType { get; set; }
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}