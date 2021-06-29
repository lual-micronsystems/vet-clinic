using FluentValidation;

namespace vet_clinic.Application.Visits.Queries.GetVisits
{
    public class GetVisitsWithPaginationQueryValidator : AbstractValidator<GetVisitsWithPaginationQuery>
    {
        public GetVisitsWithPaginationQueryValidator()
        {
            RuleFor(x => x.PetId)
                .NotNull()
                .NotEmpty().WithMessage("PetId is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber should be at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize should be at least greater than or equal to 1.");
        }
    }
}
