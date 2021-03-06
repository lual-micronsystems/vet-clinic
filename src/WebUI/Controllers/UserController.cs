using vet_clinic.Application.Users.Queries.GetUsers;
using vet_clinic.Application.Users.Queries.SearchUsers;
using vet_clinic.Application.Users.Commands.CreateUser;
using vet_clinic.Application.Users.Commands.DeleteUser;
using vet_clinic.Application.Users.Commands.UpdateUser;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using vet_clinic.Application.Common.Models;

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

        [HttpGet]
        [Route("SearchUsersByFirstName")]
        public async Task<ActionResult<PaginatedList<UserDto>>> SearchUsersByFirstName([FromQuery] SearchUsersByFirstNameWithPaginationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("SearchUsersByLastName")]
        public async Task<ActionResult<PaginatedList<UserDto>>> SearchUsersByLastName([FromQuery] SearchUsersByLastNameWithPaginationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<int>> CreateUser(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            await Mediator.Send(new DeleteUserCommand { Id = userId });

            string v = $"Successfully deleted user with Id: {userId}";
            return Ok(v);
        } 

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUser(int userId, UpdateUserCommand command)
        {
            if (userId != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            string v = $"Successfully updated user with Id: {userId}";
            return Ok(v);
        }
    }
}
