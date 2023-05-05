using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Pedido : EntidadeBase
    {
        public Produto produto;
        public int quantidade;
        public double valorTotal;
        public Pedido(Produto produto, int quantidade)
        {
            this.produto = produto;
            this.quantidade = quantidade;
        }
        public decimal SomarValoresDosPedidos()
        {
            decimal resultado = quantidade * produto.valor;
            return resultado;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Pedido produtoAtualizado = (Pedido)registroAtualizado;

            produto = produtoAtualizado.produto;
        }
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            return erros;
        }
    }
}
