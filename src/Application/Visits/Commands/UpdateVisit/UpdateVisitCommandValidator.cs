using vet_clinic.Application.Common.Interfaces;
using FluentValidation;

namespace vet_clinic.Application.Visits.Commands.UpdateVisit
{
    public class UpdateVisitCommandValidator : AbstractValidator<UpdateVisitCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVisitCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.VisitType)
                .NotEmpty().WithMessage("VisitType is required.");

            RuleFor(v => v.VisitDate)
                .NotEmpty().WithMessage("VisitDate is required.");
            
            RuleFor(v => v.Notes)
                .NotEmpty().WithMessage("Notes is required.")
                .MaximumLength(400).WithMessage("Notes must not exceed 400 characters.");
        }
    }
}
