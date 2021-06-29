using AutoMapper;
using AutoMapper.QueryableExtensions;
using vet_clinic.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using vet_clinic.Application.Pets.Queries.GetPets;

namespace vet_clinic.Application.Visits.Queries.GetVisits
{
    public class GetVisitsQuery : IRequest<VisitsVm>
    {
        public class GetVisitsQueryHandler : IRequestHandler<GetVisitsQuery, VisitsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetVisitsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<VisitsVm> Handle(GetVisitsQuery request, CancellationToken cancellationToken)
            {
                return new VisitsVm
                {
                    Visits = await _context.Visits
                        .AsNoTracking()
                        .ProjectTo<VisitDto>(_mapper.ConfigurationProvider)
                        .OrderBy(t => t.Id)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}
