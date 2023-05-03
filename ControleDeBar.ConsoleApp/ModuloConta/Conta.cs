using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloPedidos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Mesa mesa;
        public Pedido pedido;
        public double valorTotal;
        public string status;
        public ArrayList pedidos;
        public Conta(Pedido pedido, Mesa mesa)
        {
            this.mesa = mesa;
            this.status = "Aberta";
            this.pedidos = new ArrayList();
            this.valorTotal =+ (pedido.quantidade * pedido.produto.valor);
            pedidos.Add(pedido);
        }
        public void AdicionarPedidoNaLista(Pedido pedido)
        {
            if (this.pedidos.Count > 0)
            {
                this.pedidos.Add(pedido);
            }
            else
            {
                this.pedido = pedido;
                this.pedidos.Add(this.pedido);
            }
        }
        public void SomarValoresDosPedidos(Pedido pedido)
        {
            this.valorTotal =+ pedido.valorTotal;
        }
        public void PagarConta()
        {
            this.status = "Pago";
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
