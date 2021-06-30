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
using Microsoft.EntityFrameworkCore;

namespace vet_clinic.Application.Visits.Queries.SearchVisits
{
    public class SearchVisitsByPetTypeWithPaginationQuery : IRequest<PaginatedList<VisitDto>>
    {
        public int PetType { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class SearchVisitsByPetTypeWithPaginationQueryHandler : IRequestHandler<SearchVisitsByPetTypeWithPaginationQuery, PaginatedList<VisitDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SearchVisitsByPetTypeWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<VisitDto>> Handle(SearchVisitsByPetTypeWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Visits
                .Include(v => v.Pet)
                .ThenInclude(p => p.User)
                .Where(x => x.Pet.PetType == request.PetType)
                .ProjectTo<VisitDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
