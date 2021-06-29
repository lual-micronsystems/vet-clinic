using vet_clinic.Application.Pets.Queries.GetPets;
using vet_clinic.Application.Pets.Commands.CreatePet;
using vet_clinic.Application.Pets.Commands.DeletePet;
using vet_clinic.Application.Pets.Commands.UpdatePet;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using vet_clinic.Application.Common.Models;

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

        [HttpGet]
        [Route("GetPetsByUser")]
        public async Task<ActionResult<PaginatedList<PetDto>>> GetPetsByUser([FromQuery] GetPetsWithPaginationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("CreatePet")]
        public async Task<ActionResult<int>> CreatePet(CreatePetCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{petId}")]
        public async Task<ActionResult> DeletePet(int petId)
        {
            await Mediator.Send(new DeletePetCommand { Id = petId });

            string v = $"Successfully deleted pet record with Id: {petId}";
            return Ok(v);
        } 

        [HttpPut("{petId}")]
        public async Task<ActionResult> UpdatePet(int petId, UpdatePetCommand command)
        {
            if (petId != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            string v = $"Successfully updated pet with Id: {petId}";
            return Ok(v);
        }
    }
}
