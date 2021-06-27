using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }
        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
            Itens = new List<Item>();
        }
        private void AdicionarItem(Produto produto, int qtde)
        {           
            Itens.Add(new Item(produto, qtde));           
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (itens.Count() == 0) throw new BusinessRuleException("A solicitação de compra deve possuir itens!");

            foreach (var item in itens)
            {
                AdicionarItem(item.Produto, item.Qtde);
            }
            
            AdicionarPrazoPagamento(itens);

        }
        private void AdicionarPrazoPagamento(IEnumerable<Item> itens)
        {                        
            var total = itens.Where(x => x.Qtde * x.Produto.Preco.Value > 50000).Any();

            if (total)
                CondicaoPagamento = new CondicaoPagamento(30);
            else
                CondicaoPagamento = new CondicaoPagamento(0);
        }
    }
}
