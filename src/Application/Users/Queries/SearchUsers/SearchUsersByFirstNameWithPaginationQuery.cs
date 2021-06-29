using AutoMapper;
using AutoMapper.QueryableExtensions;
using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Application.Common.Mappings;
using vet_clinic.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using vet_clinic.Application.Users.Queries.GetUsers;

namespace vet_clinic.Application.Users.Queries.SearchUsers
{
    public class SearchUsersByFirstNameWithPaginationQuery : IRequest<PaginatedList<UserDto>>
    {
        public string FirstName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class SearchUsersByFirstNameWithPaginationQueryHandler : IRequestHandler<SearchUsersByFirstNameWithPaginationQuery, PaginatedList<UserDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SearchUsersByFirstNameWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<UserDto>> Handle(SearchUsersByFirstNameWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(x => x.FirstName.Contains(request.FirstName))
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
