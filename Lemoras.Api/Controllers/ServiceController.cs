using Microsoft.AspNetCore.Mvc;

namespace Lemoras.Api.Controllers
{
    public abstract class ServiceController<TService> : ControllerBase where TService : class
    {
        internal protected readonly TService _service;
        
        protected ServiceController(TService service)
        {
            this._service = service;
        }

        [Produces("application/json")]
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Service is running..");
        }
    }
}