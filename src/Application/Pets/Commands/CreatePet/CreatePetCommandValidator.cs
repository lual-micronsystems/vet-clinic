using vet_clinic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
    {
        private readonly IApplicationDbContext _context;
        
        public CreatePetCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.PetName)
                .NotEmpty().WithMessage("PetName is required.")
                .MaximumLength(200).WithMessage("PetName must not exceed 200 characters.");

            RuleFor(v => v.PetType)
                .NotEmpty().WithMessage("PetType is required.");
            
            RuleFor(v => v.Breed)
                .MaximumLength(200).WithMessage("Breed must not exceed 400 characters.");

            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage("UserId is required.")
                .MustAsync(UserExists).WithMessage("The specified UserId does not exist.");
        }

        public async Task<bool> UserExists(int userId, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AnyAsync(l => l.Id == userId);
        }
    }
}
