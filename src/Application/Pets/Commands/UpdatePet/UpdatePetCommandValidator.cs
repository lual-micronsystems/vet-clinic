using vet_clinic.Application.Common.Interfaces;
using FluentValidation;

namespace vet_clinic.Application.Pets.Commands.UpdatePet
{
    public class UpdatePetCommandValidator : AbstractValidator<UpdatePetCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePetCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.PetName)
                .NotEmpty().WithMessage("PetName is required.")
                .MaximumLength(200).WithMessage("PetName must not exceed 200 characters.");

            RuleFor(v => v.PetType)
                .NotEmpty().WithMessage("PetType is required.");
            
            RuleFor(v => v.Breed)
                .MaximumLength(200).WithMessage("Breed must not exceed 400 characters.");
        }

    }
}
