using FluentValidation;

namespace vet_clinic.Application.Pets.Queries.GetPets
{
    public class GetPetsWithPaginationQueryValidator : AbstractValidator<GetPetsWithPaginationQuery>
    {
        public GetPetsWithPaginationQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty().WithMessage("UserId is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber should be at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize should be at least greater than or equal to 1.");
        }
    }
}
