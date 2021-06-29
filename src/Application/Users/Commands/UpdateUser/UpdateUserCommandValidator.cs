using vet_clinic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(200).WithMessage("FirstName must not exceed 200 characters.");

            RuleFor(v => v.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .MaximumLength(200).WithMessage("LastName must not exceed 200 characters.");
            
            RuleFor(v => v.MiddleName)
                .MaximumLength(200).WithMessage("MiddleName must not exceed 200 characters.");
            
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Not a valid email address.")
                .MaximumLength(200).WithMessage("Email must not exceed 200 characters.");

            RuleFor(v => v.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MaximumLength(200).WithMessage("UserName must not exceed 200 characters.")
                .MustAsync(BeUniqueUserName).WithMessage("The specified username already exists.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MaximumLength(10).WithMessage("Password must not exceed 10 characters.");

            RuleFor(v => v.UserType)
                .NotEmpty().WithMessage("UserType is required.")
                .InclusiveBetween(1, 2).WithMessage("Only accepted values are 1 - Admin or 2 - Pet Owner.");

            RuleFor(v => v.Active)
                .InclusiveBetween(0, 1).WithMessage("Only accepted values are 0 - Inactive or 1 - Active.");
        }

        public async Task<bool> BeUniqueUserName(UpdateUserCommand model, string userName, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.UserName != userName);
        }
    }
}
