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
        [HttpPost]
        public GenericCommandResult Create(CriarOfertaCommand command,
                                                [FromServices] CriarOfertaCommandHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }
    }

    //[Route("v1/show-offers")]
    //public GenericQueryResult GetAll([FromServices] ListarOfertaQueryHandle handle)
    //{
    //    //verifica nivel de acesso do Usuario
    //    ListarOfertaQuery query = new ListarOfertaQuery();

    //    var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);

    //    if (tipoUsuario.Value.ToString() == EnTipoUsuario.Comum.ToString())
    //        query.Ativo = true;

    //    return (GenericQueryResult)handle.Handle(query);

    //}
}
