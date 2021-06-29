using vet_clinic.Application.Common.Models;
// using vet_clinic.Application.TodoItems.Commands.CreateTodoItem;
// using vet_clinic.Application.TodoItems.Commands.DeleteTodoItem;
// using vet_clinic.Application.TodoItems.Commands.UpdateTodoItem;
// using vet_clinic.Application.TodoItems.Commands.UpdateTodoItemDetail;
using vet_clinic.Application.Visits.Queries.GetVisits;
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
            return await Mediator.Send(query);
        }

        /* [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTodoItemCommand { Id = id });

            return NoContent();
        } */
    }
}
