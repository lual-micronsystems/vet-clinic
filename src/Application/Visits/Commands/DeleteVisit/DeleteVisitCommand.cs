using vet_clinic.Application.Common.Exceptions;
using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.Visits.Commands.DeleteVisit
{
    public class DeleteVisitCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteVisitCommandHandler : IRequestHandler<DeleteVisitCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVisitCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Visits.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Visit), request.Id);
            }

            _context.Visits.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
