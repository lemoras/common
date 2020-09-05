using Lemoras.Domain.Parts;
using Microsoft.AspNetCore.Mvc;

namespace Lemoras.Api.Controllers
{
    public abstract class ContextController<TModel> : ControllerBase where TModel : Entity
    {
        internal protected readonly IContext<TModel> _context;

        public ContextController(IContext<TModel> context)
        {
            this._context = context;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Service is running..");
        }
    }
}