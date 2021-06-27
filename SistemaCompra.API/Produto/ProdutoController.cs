using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.Produto.Command.AtualizarPreco;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using System;
using System.Net;

namespace SistemaCompra.API.Produto
{
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Obtem um produto por Id.
        /// </summary>
        /// <param name="id">idenificador do produto</param>
        [HttpGet, Route("produto/{id}")]
        public IActionResult Obter(Guid id)
        {
            var query = new ObterProdutoQuery() { Id = id };
            var produtoViewModel = _mediator.Send(query);
            return Ok(produtoViewModel);
        }


        /// <summary>
        ///Cadastro de um produto.
        /// </summary>
        /// <param name="registrarProdutoCommand">modelo registro de produto</param>
        /// <response code="201">Requisição criada com sucesso</response>
        /// <response code="400">sintaxe invalida values</response>
        /// <response code="404">não encontrado</response>
        /// <response code="500">Erro encontrdo</response>
        [HttpPost, Route("produto/cadastro")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CadastrarProduto([FromBody] RegistrarProdutoCommand registrarProdutoCommand)
        {
            try
            {
                _mediator.Send(registrarProdutoCommand);
                return StatusCode(201);
            }
            catch (WebException webException)
            {
                var httpResponse = (HttpWebResponse)webException.Response;
                return StatusCode((int)httpResponse.StatusCode);
            }

        }
        /// <summary>
        ///Atualizar produto.
        /// </summary>
        /// <param name="Id">identificador do produto</param>
        /// <param name="Preco">preço do produto</param>      
        /// <response code="200">Requisição bem sucedida</response>
        /// <response code="400">sintaxe invalida values</response>
        /// <response code="404">não encontrado</response>
        /// <response code="500">Erro encontrdo</response>
        [HttpPut, Route("produto/atualiza-preco")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult AtualizarPreco([FromBody] AtualizarPrecoCommand atualizarPrecoCommand)
        {
            _mediator.Send(atualizarPrecoCommand);
            return Ok();

        }
    }
}
