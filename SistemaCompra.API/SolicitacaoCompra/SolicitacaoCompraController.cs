using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;

namespace SistemaCompra.API.Produto
{
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        /// <summary>
        ///Registrar uma nova compra.
        /// </summary>
        /// <param name="registrarCompraCommand">modelo registro de compras</param>               
        /// <response code="201">Requisição criada com sucesso</response>
        /// <response code="400">sintaxe invalida values</response>
        /// <response code="404">não encontrado</response>
        /// <response code="500">Erro encontrdo</response>
        [HttpPost, Route("solicitacao/registrar")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult RegistrarCompra([FromBody] RegistrarCompraCommand registrarCompraCommand)
        {
            try
            {
                _mediator.Send(registrarCompraCommand);
                return StatusCode(201);
            }
            catch(WebException webException)
            {
                var httpResponse = (HttpWebResponse)webException.Response;
                return StatusCode((int)httpResponse.StatusCode);
            }                
        }
      
    }
}
