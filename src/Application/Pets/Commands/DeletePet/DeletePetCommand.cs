using vet_clinic.Application.Common.Exceptions;
using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.Pets.Commands.DeletePet
{
    public class DeletePetCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePetCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePetCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Pets
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Pet), request.Id);
            }

            _context.Pets.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
