using AutoMapper;
using AutoMapper.QueryableExtensions;
using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Application.Common.Mappings;
using vet_clinic.Application.Common.Models;
using vet_clinic.Application.Pets.Queries.GetPets;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.Visits.Queries.GetVisits
{
    public class GetVisitsWithPaginationQuery : IRequest<PaginatedList<VisitDto>>
    {
        public int PetId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetVisitsWithPaginationQueryHandler : IRequestHandler<GetVisitsWithPaginationQuery, PaginatedList<VisitDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVisitsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<VisitDto>> Handle(GetVisitsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Visits
                .Where(x => x.PetId == request.PetId)
                .ProjectTo<VisitDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
