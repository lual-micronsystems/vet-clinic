using vet_clinic.Application.Users.Commands.CreateUser;
// using vet_clinic.Application.Users.Commands.DeleteTodoList;
// using vet_clinic.Application.Users.Commands.UpdateTodoList;
using vet_clinic.Application.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace vet_clinic.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ApiControllerBase
    {
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<UsersVm>> GetUsers()
        {
            return Ok(await Mediator.Send(new GetUsersQuery()));
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<int>> CreateUser(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        /*
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
