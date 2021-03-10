using Microsoft.AspNetCore.Mvc;
using Ofertas.Comum.Commands;
using Ofertas.Dominio.Commands.Oferta;
using Ofertas.Dominio.Handlers.Ofertas;

namespace Ofertas.Api.Controllers
{
    [Route("v1/offers")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        [HttpPost]
        public GenericCommandResult Create(CriarOfertaCommand command,
                                                [FromServices] CriarOfertaCommandHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }
    }
}
