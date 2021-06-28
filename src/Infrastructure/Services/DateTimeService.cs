using vet_clinic.Application.Common.Interfaces;
using System;

namespace vet_clinic.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
