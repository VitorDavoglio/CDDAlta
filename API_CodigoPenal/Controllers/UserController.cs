using CQRS_CodigoPenal.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API_CodigoPenal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        public UserController(IMediator bus, ILogger<UserController> logger) : base(bus, logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> NovoUsusario([FromBody] AddUser command)
        {
            return await CreateResponse(async () => await _bus.Send(command));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthUser command)
        {
            return await CreateResponse(async () => await _bus.Send(command));
        }
    }
}
