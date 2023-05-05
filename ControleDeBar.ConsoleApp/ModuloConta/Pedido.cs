using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.Compartilhado.Interface;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Pedido : EntidadeBase<Pedido>
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
        public override void AtualizarInformacoes(Pedido registroAtualizado)
        {
            produto = registroAtualizado.produto;
        }
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            return erros;
        }
    }
}
