using Microsoft.AspNetCore.Mvc;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Commands.Oferta;
using Ofertas.Dominio.Commands.Reserva;
using Ofertas.Dominio.Handlers.Reservas;
using Ofertas.Dominio.Queries.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ofertas.Api.Controllers
{
    [Route("v1/reservas")]
    [ApiController]
    public class ReservaController : Controller
    {
        [Route("add-reserva")]
        [HttpPost]
        public GenericCommandResult Create(CriarReservaCommand command,
                                                [FromServices] CriarReservaCommandHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [Route("reservas")]
        [HttpGet]
        public GenericQueryResult GetAll([FromServices] ListarReservaQueryHandler handle)
        {
            ListarReservasQuery query = new ListarReservasQuery();

            return (GenericQueryResult)handle.Handle(query);

        }
    }
}
