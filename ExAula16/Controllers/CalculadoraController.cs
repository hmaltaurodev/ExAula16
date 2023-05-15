using ExAula16.Domain;
using ExAula16.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ExAula16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        public CalculadoraHandler _handler;

        public CalculadoraController()
        {
            _handler = new CalculadoraHandler();
        }

        [HttpPost]
        [Route("executar")]
        public async Task<IActionResult> Executar([FromBody] Parametros parametros)
        {
            return _handler.Handle(parametros);
        }
    }
}
