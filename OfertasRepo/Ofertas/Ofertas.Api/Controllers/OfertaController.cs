using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Commands.Oferta;
using Ofertas.Dominio.Commands.Pacote;
using Ofertas.Dominio.Handlers.Oferta;
using Ofertas.Dominio.Handlers.Ofertas;
using Ofertas.Dominio.Handlers.Pacotes;
using Ofertas.Dominio.Queries.Oferta;
using System;
using System.Linq;
using System.Security.Claims;

namespace Ofertas.Api.Controllers
{
    [Route("v1/offers")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        /// <summary>
        /// Cadastra uma nova oferta
        /// </summary>
        /// <param name="command"></param>
        /// <param name="handle"></param>
        /// <returns></returns>
        [Route("add-offers")]
        [HttpPost]
        public GenericCommandResult Create(CriarOfertaCommand command,
                                                [FromServices] CriarOfertaCommandHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        /// <summary>
        /// Lista todas as ofertas
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [HttpGet]
        public GenericQueryResult GetAll(
            [FromServices] ListarOfertaQueryHandle handle)
        {
            ListarOfertaQuery query = new ListarOfertaQuery();

            return (GenericQueryResult)handle.Handle(query);

        }

        [HttpGet("{id}")]
        //[Authorize]
        public GenericCommandResult GetById(Guid id, [FromServices] BuscarOfertaPorIdQueryHandler handle)
        {
            BuscarOfertaPorIdQuery query = new BuscarOfertaPorIdQuery();

            //var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            query.IdOferta = id;
           // query.TipoUsuario = (EnTipoUsuario)Enum.Parse(typeof(EnTipoUsuario), tipoUsuario.Value);

            return (GenericCommandResult)handle.Handle(query);
        }

        /// <summary>
        /// Altera as propriedades da oferta
        /// </summary>
        /// <param name="id">id da Oferta</param>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public GenericCommandResult Update(Guid id,
           [FromBody] AlterarOfertaCommand command,
           [FromServices] AlterarOfertaCommandHandler handler)
        {
            if (id == Guid.Empty)
                return new GenericCommandResult(false, "Informe o Id da Oferta", "");

            command.IdOferta = id;

            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Altera a imagem da Oferta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        [HttpPut("{id}/image")]
        public GenericCommandResult UpdateImage(Guid id,
            [FromBody] AlterarImagemOfertaCommand command,
            [FromServices] AlterarImagemHandler handler
        )
        {
            if (id == Guid.Empty)
                return new GenericCommandResult(false, "Informe o Id da Oferta", "");

            command.IdOferta = id;

            return (GenericCommandResult)handler.Handle(command);
        }


    }
}
