using vet_clinic.Application.Common.Models;
using vet_clinic.Application.Visits.Queries.GetVisits;
using vet_clinic.Application.Visits.Queries.SearchVisits;
using vet_clinic.Application.Visits.Commands.CreateVisit;
using vet_clinic.Application.Visits.Commands.DeleteVisit;
using vet_clinic.Application.Visits.Commands.UpdateVisit;
using vet_clinic.Application.Pets.Queries.GetPets;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace vet_clinic.WebUI.Controllers
{
    public class VisitController : ApiControllerBase
    {

        [HttpGet]
        [Route("GetVisits")]
        public async Task<ActionResult<VisitsVm>> GetVisits()
        {
            return Ok(await Mediator.Send(new GetVisitsQuery()));
        }

        [HttpGet]
        [Route("GetVisitsByPet")]
        public async Task<ActionResult<PaginatedList<VisitDto>>> GetVisitsByPet([FromQuery] GetVisitsWithPaginationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("SearchVisitsByType")]
        public async Task<ActionResult<PaginatedList<VisitDto>>> SearchVisitsByType([FromQuery] SearchVisitsByTypeWithPaginationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("SearchVisitsByDateRange")]
        public async Task<ActionResult<PaginatedList<VisitDto>>> SearchVisitsByDateRange([FromQuery] SearchVisitsByDateRangeWithPaginationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("CreateVisit")]
        public async Task<ActionResult<int>> CreateVisit(CreateVisitCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("{visitId}")]
        public async Task<ActionResult> DeleteVisit(int visitId)
        {
            await Mediator.Send(new DeleteVisitCommand { Id = visitId });

            string v = $"Successfully deleted visit record with Id: {visitId}";
            return Ok(v);
        }

        [HttpPut("{visitId}")]
        public async Task<ActionResult> UpdateVisit(int visitId, UpdateVisitCommand command)
        {
            if (visitId != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            string v = $"Successfully updated visit record with Id: {visitId}";
            return Ok(v);
        }
    }
}
