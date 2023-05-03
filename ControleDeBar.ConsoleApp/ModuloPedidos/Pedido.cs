using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloPedidos
{
    public class Pedido : EntidadeBase
    {
        public Produto produto;
        public int quantidade;
        public Pedido(Produto produto, int quantidade)
        {
            this.produto = produto;
            this.quantidade = quantidade;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Pedido produtoAtualizado = (Pedido)registroAtualizado;

            this.produto = produtoAtualizado.produto;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            return erros;
        }
    }
}
