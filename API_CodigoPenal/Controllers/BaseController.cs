using API_CodigoPenal.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API_CodigoPenal.Controllers
{
    public class BaseController : Controller
    {

        public readonly IMediator _bus;
        private readonly ILogger<BaseController> _log;

        public BaseController(IMediator bus, ILogger<BaseController> log)
        {
            _bus = bus;
            _log = log;
        }

        [NonAction]
        public async Task<IActionResult> CreateResponse<T>(Func<Task<T>> function)
        {
            try
            {
                var data = await function();
                return Ok(new Success<T>(data));
            }
            catch (Exception ex)
            {
                return StatusCode(Error.GetStatusCode(ex), new Error(ex));
            }
        }

        [NonAction]
        public async Task<IActionResult> CreateResponse(Func<Task> function)
        {
            try
            {
                await function();
                return Ok(new Success<object>(null));
            }
            catch (Exception ex)
            {
                return StatusCode(Error.GetStatusCode(ex), new Error(ex));
            }
        }
    }
}
