using FluentValidation;

namespace vet_clinic.Application.Visits.Queries.SearchVisits
{
    public class SearchVisitsByDateRangeWithPaginationQueryValidator : AbstractValidator<SearchVisitsByDateRangeWithPaginationQuery>
    {
        public SearchVisitsByDateRangeWithPaginationQueryValidator()
        {
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("StartDate is required.");
            
            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("EndDate is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber should be at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize should be at least greater than or equal to 1.");
        }
    }
}
