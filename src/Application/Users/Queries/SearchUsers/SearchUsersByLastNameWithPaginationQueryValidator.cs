using FluentValidation;

namespace vet_clinic.Application.Users.Queries.SearchUsers
{
    public class SearchUsersByLastNameWithPaginationQueryValidator : AbstractValidator<SearchUsersByLastNameWithPaginationQuery>
    {
        public SearchUsersByLastNameWithPaginationQueryValidator()
        {
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .MaximumLength(200).WithMessage("LastName must not exceed 200 characters.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber should be at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize should be at least greater than or equal to 1.");
        }
    }
}
