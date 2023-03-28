using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSventa.Models.Request;
using WSventa.Services;
using WSventa.Models.Response;

namespace WSventa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public IActionResult Autentifcar([FromBody] AuthRequest model)
        {
            Response response = new Response();
            var userresponse = _userService.Auth(model);

            if (userresponse == null)
            {
                response.Exito = 0;
                response.Mensaje = "User or Passowrd are Wrong";

                return BadRequest(response);
            }

            response.Exito = 1;
            response.Data = userresponse;
            return Ok(response);
        }
    }
}
