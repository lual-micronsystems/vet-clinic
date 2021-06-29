using AutoMapper;
using AutoMapper.QueryableExtensions;
using vet_clinic.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.Pets.Queries.GetPets
{
    public class GetPetsQuery : IRequest<PetsVm>
    {
        public class GetPetsQueryHandler : IRequestHandler<GetPetsQuery, PetsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetPetsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PetsVm> Handle(GetPetsQuery request, CancellationToken cancellationToken)
            {
                return new PetsVm
                {
                    Pets = await _context.Pets
                        .AsNoTracking()
                        .ProjectTo<PetDto>(_mapper.ConfigurationProvider)
                        .OrderBy(t => t.Id)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}
