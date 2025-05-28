using HotelReservationSystem.Application.Users.LoginUser;
using HotelReservationSystem.Application.Users.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace HotelReservationSystem.Api.Controllers.Users
{
    [ApiController]    
    [Route("api/v{version:apiVersion}/users")]
    public class UsersController : Controller
    {
        private readonly ISender _sender;

        public UsersController(ISender sender)
        {
            _sender = sender;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginUserRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new LoginCommand(request.Email, request.Password);
            var result = await _sender.Send(command, cancellationToken);
            
            if (result.IsFailure)
            {
                return Unauthorized(result.Error);
            }
            return Ok(result.Value);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(
        [FromBody] RegisterUserRequest request,
        CancellationToken cancellationToken)
        {
            var command = new RegisterUserCommand(
                request.Email,
                request.Nombre,
                request.Apellidos,
                request.Password
            );
            var result  = await _sender.Send(command,cancellationToken);
            if (result.IsFailure)
            { 
                return Unauthorized(result.Error);
            }
            return Ok(result.Value);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
