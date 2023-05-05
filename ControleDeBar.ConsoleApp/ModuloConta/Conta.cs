using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.Compartilhado.Enums;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Pedido pedido;
        public Mesa mesa;
        public Garcom garcom;
        public double valorTotal;
        public StatusConta status;

        public DateTime data;

        public ArrayList pedidos;
        public Conta(Mesa _mesa, Garcom _garcom, DateTime _dataAbertura)
        {
            this.mesa = _mesa;
            this.garcom = _garcom;
            this.data = _dataAbertura;
            this.status = StatusConta.Aberto;

            this.pedidos = new ArrayList();
            Abrir();
        }
        public void PagarConta()
        {
            Fechar();
        }
        public void RegistrarPedido(Produto produto, int quantidade)
        {
            Pedido novoPedido = new Pedido(produto, quantidade);
            pedidos.Add(novoPedido);
        }
        public decimal CalcularValorTotal()
        {
            decimal total = 0;
            foreach (Pedido pedido in pedidos)
            {
                decimal totalPedido = pedido.SomarValoresDosPedidos();
                total += totalPedido;
            }
            return total;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta produtoAtualizado = (Conta)registroAtualizado;

            this.pedido = produtoAtualizado.pedido;
            this.mesa = produtoAtualizado.mesa;
        }
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
            if (garcom == null)
            {
                erros.Add("O campo \"Garçom\" é obrigatorio");
            }
            if (mesa == null)
            {
                erros.Add("O campo \"Mesa\" é obrigatorio");
            }
            return erros;
        }
        private void Abrir()
        {
            status = StatusConta.Aberto;
            mesa.Ocupar();
        }
        private void Fechar()
        {
            status = StatusConta.Pago;
            mesa.Desocupar();
        }
    }
}
