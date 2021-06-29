using AutoMapper;
using AutoMapper.QueryableExtensions;
using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Application.Common.Mappings;
using vet_clinic.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using vet_clinic.Application.Pets.Queries.GetPets;

namespace vet_clinic.Application.Visits.Queries.SearchVisits
{
    public class SearchVisitsByTypeWithPaginationQuery : IRequest<PaginatedList<VisitDto>>
    {
        public int VisitType { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class SearchVisitsByTypeWithPaginationQueryHandler : IRequestHandler<SearchVisitsByTypeWithPaginationQuery, PaginatedList<VisitDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SearchVisitsByTypeWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<VisitDto>> Handle(SearchVisitsByTypeWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Visits
                .Where(x => x.VisitType == request.VisitType)
                .ProjectTo<VisitDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
