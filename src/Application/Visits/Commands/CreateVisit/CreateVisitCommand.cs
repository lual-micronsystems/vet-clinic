using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace vet_clinic.Application.Visits.Commands.CreateVisit
{
    public class CreateVisitCommand : IRequest<int>
    {
        public int VisitType { get; set; }
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; }
        public int PetId { get; set; }
    }

    public class CreateVisitCommandHandler : IRequestHandler<CreateVisitCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateVisitCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
        {
            var entity = new Visit
            {
                VisitType = request.VisitType,
                VisitDate = request.VisitDate,
                Notes = request.Notes,
                PetId = request.PetId
            };

            _context.Visits.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
