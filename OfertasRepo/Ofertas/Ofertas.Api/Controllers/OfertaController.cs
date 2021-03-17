﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Commands.Comentario;
using Ofertas.Dominio.Commands.Oferta;
using Ofertas.Dominio.Commands.Pacote;
using Ofertas.Dominio.Handlers.Comentarios;
using Ofertas.Dominio.Handlers.Ofertas;
using Ofertas.Dominio.Handlers.Pacotes;
using Ofertas.Dominio.Queries.Comentarios;
using Ofertas.Dominio.Queries.Ofertas;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

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
        [HttpPost]
        public GenericCommandResult Create(CriarOfertaCommand command,
                                                [FromServices] CriarOfertaCommandHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [HttpPost("{id}/comments")]
        //[Authorize]
        public GenericCommandResult AddComments(Guid id,
                                                [FromBody] CriarComentarioCommand command,
                                                [FromServices] CriarComentarioCommandHandler handler)
        {
            if (id == Guid.Empty)
                return new GenericCommandResult(false, "Id da Oferta não informado", null);

            command.IdOferta = id;

            //var idUsuario = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);
            //command.IdUsuario = new Guid(idUsuario.Value);

            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet("{id}/comments")]
        public GenericQueryResult GetAllComments(
            [FromServices] ListarComentariosQueryHandler handle)
        {
            ListarComentariosQuery query = new ListarComentariosQuery();

            return (GenericQueryResult)handle.Handle(query);

        }

        [Route("change-status-donation")]
        [HttpPost]
        public GenericCommandResult ChangeStatusDonation(AlterarStatusDoacaoOfertaCommand command,
                                                [FromServices] AlterarStatusDoacaoOfertaCommandHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [Route("change-status-active")]
        [HttpPost]
        public GenericCommandResult ChangeStatusActive(AlterarStatusAtivoOfertaCommand command,
                                                [FromServices] AlterarStatusAtivoOfertaCommandHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [Route("products")]
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

    }
}
