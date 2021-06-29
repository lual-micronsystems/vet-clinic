using vet_clinic.Application.Common.Exceptions;
using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace vet_clinic.Application.Pets.Commands.UpdatePet
{
    public class UpdatePetCommand : IRequest
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public int PetType { get; set; }
        public string Breed { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePetCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Pets.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Pet), request.Id);
            }

            entity.PetName = request.PetName;
            entity.PetType = request.PetType;
            entity.Breed = request.Breed;
            entity.BirthDate = request.BirthDate;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
