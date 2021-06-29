using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace vet_clinic.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommand : IRequest<int>
    {
        public string PetName { get; set; }
        public int PetType { get; set; }
        public string Breed { get; set; }
        public DateTime? BirthDate { get; set; }
        public int UserId { get; set; }
    }

    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePetCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<int> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            var entity = new Pet
            {
                PetName = request.PetName,
                PetType = request.PetType,
                Breed = request.Breed,
                BirthDate = request.BirthDate,
                UserId = request.UserId
            };

            _context.Pets.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
        
    }
}
