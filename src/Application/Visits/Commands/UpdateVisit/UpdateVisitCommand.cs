using vet_clinic.Application.Common.Exceptions;
using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace vet_clinic.Application.Visits.Commands.UpdateVisit
{
    public class UpdateVisitCommand : IRequest
    {
        public int Id { get; set; }
        public int VisitType { get; set; }
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; }
    }

    public class UpdateVisitCommandHandler : IRequestHandler<UpdateVisitCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVisitCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Visits.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Visit), request.Id);
            }

            entity.VisitType = request.VisitType;
            entity.VisitDate = request.VisitDate;
            entity.Notes = request.Notes;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
