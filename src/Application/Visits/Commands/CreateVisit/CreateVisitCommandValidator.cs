using vet_clinic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.Visits.Commands.CreateVisit
{
    public class CreateVisitCommandValidator : AbstractValidator<CreateVisitCommand>
    {
        private readonly IApplicationDbContext _context;
        
        public CreateVisitCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.VisitType)
                .NotEmpty().WithMessage("VisitType is required.");

            RuleFor(v => v.VisitDate)
                .NotEmpty().WithMessage("VisitDate is required.");
            
            RuleFor(v => v.Notes)
                .NotEmpty().WithMessage("Notes is required.")
                .MaximumLength(400).WithMessage("Notes must not exceed 400 characters.");

            RuleFor(v => v.PetId)
                .NotEmpty().WithMessage("PetId is required.")
                .MustAsync(PetExists).WithMessage("The specified PetId does not exist.");
        }

        public async Task<bool> PetExists(int petId, CancellationToken cancellationToken)
        {
            return await _context.Pets
                .AnyAsync(l => l.Id == petId);
        }
    }
}
