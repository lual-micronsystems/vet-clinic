using vet_clinic.Application.Common.Exceptions;
using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public int? Active { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.MiddleName = request.MiddleName;
            entity.Email = request.Email;
            entity.UserName = request.UserName;
            entity.Password = request.Password;
            entity.UserType = request.UserType;
            entity.Active = request.Active;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
