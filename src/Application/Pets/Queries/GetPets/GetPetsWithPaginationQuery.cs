using AutoMapper;
using AutoMapper.QueryableExtensions;
using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Application.Common.Mappings;
using vet_clinic.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.Pets.Queries.GetPets
{
    public class GetPetsWithPaginationQuery : IRequest<PaginatedList<PetDto>>
    {
        public int UserId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetPetsWithPaginationQueryHandler : IRequestHandler<GetPetsWithPaginationQuery, PaginatedList<PetDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPetsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PetDto>> Handle(GetPetsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Pets
                .Where(x => x.UserId == request.UserId)
                .ProjectTo<PetDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
