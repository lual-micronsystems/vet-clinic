using FluentValidation;

namespace vet_clinic.Application.Visits.Queries.SearchVisits
{
    public class SearchVisitsByPetTypeWithPaginationQueryValidator : AbstractValidator<SearchVisitsByPetTypeWithPaginationQuery>
    {
        public SearchVisitsByPetTypeWithPaginationQueryValidator()
        {
            RuleFor(x => x.PetType)
                .NotEmpty().WithMessage("PetType is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber should be at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize should be at least greater than or equal to 1.");
        }
    }
}
