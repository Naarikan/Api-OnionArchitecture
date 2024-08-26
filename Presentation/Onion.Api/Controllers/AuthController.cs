using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Features.Auth.Command.Login;
using Onion.Application.Features.Auth.Command.RefreshToken;
using Onion.Application.Features.Auth.Command.Register;
using Onion.Application.Features.Auth.Command.Revoke;
using Onion.Application.Features.Auth.Command.RevokeAll;

namespace Onion.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
          var response = await mediator.Send(request);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            var response = await mediator.Send(new RevokeAllCommandRequest());
            return Ok();
        }
    }
}
