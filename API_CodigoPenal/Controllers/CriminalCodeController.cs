using CQRS_CodigoPenal.Commands;
using CQRS_CodigoPenal.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API_CodigoPenal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriminalCodeController : BaseController
    {
        private readonly ILogger<CriminalCodeController> _logger;

        public CriminalCodeController(IMediator bus, ILogger<CriminalCodeController> logger) : base(bus, logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> NovoCodigoCriminal([FromBody] AddCriminalCode command)
        {
            return await CreateResponse(async () => await _bus.Send(command));
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AtualizarCodigoCriminal([FromBody] UpdateCriminalCode command)
        {
            return await CreateResponse(async () => await _bus.Send(command));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> FiltrarUsuarios([FromQuery] CriminalCodeQuery command)
        {
            return await CreateResponse(async () => await _bus.Send(command));
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Deletar([FromQuery] DeleteCriminalCode command)
        {
            return await CreateResponse(async () => await _bus.Send(command));
        }
    }
}
