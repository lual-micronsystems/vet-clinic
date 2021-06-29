// using vet_clinic.Application.Pets.Commands.CreateTodoList;
// using vet_clinic.Application.Pets.Commands.DeleteTodoList;
// using vet_clinic.Application.Pets.Commands.UpdateTodoList;
using vet_clinic.Application.Pets.Queries.GetPets;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace vet_clinic.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class PetController : ApiControllerBase
    {
        [HttpGet]
        [Route("GetPets")]
        public async Task<ActionResult<PetsVm>> GetPets()
        {
            return Ok(await Mediator.Send(new GetPetsQuery()));
        }

        // [HttpGet("{id}")]
        /* public async Task<ActionResult> Get(int id)
        {
            var vm = await Mediator.Send(new GetUserByIdQuery { UserId = id });
        } */

        /* [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoListCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTodoListCommand command)
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
            await Mediator.Send(new DeleteTodoListCommand { Id = id });

            return NoContent();
        } */
    }
}
