using AutoMapper;
using AutoMapper.QueryableExtensions;
using vet_clinic.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.Users.Queries.GetUsers
{
    public class GetUserByIdQuery : IRequest<UsersVm>
    {
        public int UserId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UsersVm>
    {
        private readonly IApplicationDbContext _context;

        public GetUserByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsersVm> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var vm = new UsersVm();

            var records = await _context.Users
                    .Where(t => t.Id == request.UserId)
                    .ToListAsync(cancellationToken);

            return await Task.FromResult(vm);
        }
    }
}
