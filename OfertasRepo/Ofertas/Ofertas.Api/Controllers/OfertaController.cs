using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Commands.Oferta;
using Ofertas.Dominio.Handlers.Ofertas;
using Ofertas.Dominio.Handlers.Pacotes;
using Ofertas.Dominio.Queries.Oferta;

namespace Ofertas.Api.Controllers
{
    [Route("v1/offers")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        [Route("add-products")]
        [HttpPost]
        public GenericCommandResult Create(CriarOfertaCommand command,
                                                [FromServices] CriarOfertaCommandHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [Route("products")]
        [HttpGet]
        public GenericQueryResult GetAll([FromServices] ListarOfertaQueryHandle handle)
        {
            ListarOfertaQuery query = new ListarOfertaQuery();

            return (GenericQueryResult)handle.Handle(query);

        }

    }
}
