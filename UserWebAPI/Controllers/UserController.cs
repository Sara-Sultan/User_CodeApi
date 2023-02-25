using Application.DTO;
using Application.Global;
using Application.IServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [ApiController]
    [Route("api/User")]
    [EnableCors("AllowOrigin")]
    //[AppAuthorize]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager, ILogger<UserController> logger)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser([FromQuery] PagingInputDto pagingInputDto, CancellationToken cancellationToken)
        {
            var User = await _serviceManager.UserService.GetAllAsync(pagingInputDto, cancellationToken);

            return Ok(User);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetuserById(string userId, CancellationToken cancellationToken)
        {
            var userDto = await _serviceManager.UserService.GetByIdAsync(userId, cancellationToken);

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Createuser([FromBody] UserForCreationDto userForCreationDto)
        {
            var userDto = await _serviceManager.UserService.CreateAsync(userForCreationDto);

            // return CreatedAtAction(nameof(GetuserById), new { userId = userDto.Id }, userDto);
            return Ok(new ResponseDTO()
            {
                success = true,
                result = userDto,
                message = ""
            });
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Updateuser(string userId, [FromBody] UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.UserService.UpdateAsync(userId, userForUpdateDto, cancellationToken);

            return Ok(new ResponseDTO()
            {
                success = true,
                result = userForUpdateDto,
                message = ""
            });
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Deleteuser(string userId, CancellationToken cancellationToken)
        {
            await _serviceManager.UserService.DeleteAsync(userId, cancellationToken);

            return NoContent();
        }
    }

}