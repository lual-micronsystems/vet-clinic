using FluentValidation;

namespace vet_clinic.Application.Visits.Queries.SearchVisits
{
    public class SearchVisitsByTypeWithPaginationQueryValidator : AbstractValidator<SearchVisitsByTypeWithPaginationQuery>
    {
        public SearchVisitsByTypeWithPaginationQueryValidator()
        {
            RuleFor(x => x.VisitType)
                .NotEmpty().WithMessage("VisitType is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber should be at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize should be at least greater than or equal to 1.");
        }
    }
}
