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
    public class SearchUsersByLastNameWithPaginationQuery : IRequest<PaginatedList<UserDto>>
    {
        public string LastName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class SearchUsersByLastNameWithPaginationQueryHandler : IRequestHandler<SearchUsersByLastNameWithPaginationQuery, PaginatedList<UserDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SearchUsersByLastNameWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<UserDto>> Handle(SearchUsersByLastNameWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(x => x.LastName.Contains(request.LastName))
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
