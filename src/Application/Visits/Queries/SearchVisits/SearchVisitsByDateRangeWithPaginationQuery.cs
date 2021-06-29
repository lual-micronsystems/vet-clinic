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
using System;

namespace vet_clinic.Application.Visits.Queries.SearchVisits
{
    public class SearchVisitsByDateRangeWithPaginationQuery : IRequest<PaginatedList<VisitDto>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class SearchVisitsByDateRangeWithPaginationQueryHandler : IRequestHandler<SearchVisitsByDateRangeWithPaginationQuery, PaginatedList<VisitDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SearchVisitsByDateRangeWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<VisitDto>> Handle(SearchVisitsByDateRangeWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Visits
                .Where(x => x.VisitDate >= request.StartDate && x.VisitDate <= request.EndDate)
                .ProjectTo<VisitDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
