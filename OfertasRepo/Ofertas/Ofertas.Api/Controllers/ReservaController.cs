using Microsoft.AspNetCore.Mvc;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Commands.Oferta;
using Ofertas.Dominio.Commands.Reserva;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Handlers.Reservas;
using Ofertas.Dominio.Queries.Reserva;
using Ofertas.Infra.Data.Contexts;
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
        private readonly OfertasContext _context;
        public ReservaController(OfertasContext context)
        {
            _context = context;
        }

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

        [HttpGet("{id}/reservas")]
        //[Authorize]
        public IEnumerable<Reserva> GetReservasById(Guid id)
        {
            var idoferta = id.ToString();
            return _context.Reservas.Where(p => p.IdUsuario.ToString().Contains(id.ToString())).ToList();
        }
    }
}
