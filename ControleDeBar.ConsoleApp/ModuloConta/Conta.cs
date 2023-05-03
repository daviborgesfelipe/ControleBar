using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloPedidos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Pedido pedido;
        public Mesa mesa;
        public double valorTotal;
        public Conta(Pedido pedidos, Mesa mesa)
        {
            this.pedido = pedidos;
            this.mesa = mesa;
            this.valorTotal = this.valorTotal + (pedido.quantidade * pedido.produto.valor);
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta produtoAtualizado = (Conta)registroAtualizado;

            this.pedido = produtoAtualizado.pedido;
            this.mesa = produtoAtualizado.mesa;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (pedido == null)
                erros.Add("O campo \"produtos\" é obrigatório");

            return erros;
        }
    }
}
