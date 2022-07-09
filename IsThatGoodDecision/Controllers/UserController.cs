using IsThatGoodDecision.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace IsThatGoodDecision.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserResultDto>> Create([FromBody] UserDto userDto)
        {
            var user = await _userService.Create(userDto);

            if (user.Name == null)
            {
                return BadRequest(user);
            }

            return Ok(user);
        }

        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserResultDto>> Update([FromRoute] Guid id,[FromBody] UserDto userDto)
        {
            var userToUpdate = await _userService.Update(id, userDto);

            if (userToUpdate.Name == null)
            {
                return BadRequest(userToUpdate);
            }

            return Ok(userToUpdate);
        }


        [HttpDelete("delete/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserResultDto>> Delete([FromRoute] Guid id)
        {
            var userToDelete = await _userService.Delete(id);

            if (userToDelete.Name == null)
            {
                return BadRequest();
            }

            return Ok(userToDelete);
        }
    }
}
