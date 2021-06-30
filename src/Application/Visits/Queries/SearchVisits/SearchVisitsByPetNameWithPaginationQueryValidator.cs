using FluentValidation;

namespace vet_clinic.Application.Visits.Queries.SearchVisits
{
    public class SearchVisitsByPetNameWithPaginationQueryValidator : AbstractValidator<SearchVisitsByPetNameWithPaginationQuery>
    {
        public SearchVisitsByPetNameWithPaginationQueryValidator()
        {
            RuleFor(x => x.PetName)
                .NotEmpty().WithMessage("PetName is required.")
                .MaximumLength(200).WithMessage("PetName must not exceed 200 characters.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber should be at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize should be at least greater than or equal to 1.");
        }
    }
}
