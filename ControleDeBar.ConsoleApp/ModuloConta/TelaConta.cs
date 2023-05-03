using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloPedidos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        RepositorioMesa repositorioMesa;
        RepositorioPedido repositorioPedidos;
        TelaMesa telaMesa;
        TelaPedido telaPedidos;

        public TelaConta(
            RepositorioConta _repositorioConta,
            RepositorioPedido _repositorioPedidos,
            RepositorioMesa _repositorioMesa,
            TelaMesa _telaMesa,
            TelaPedido _telaPedidos
            )
        {
            this.repositorioBase = _repositorioConta;
            this.repositorioPedidos = _repositorioPedidos;
            this.repositorioMesa = _repositorioMesa;
            this.telaPedidos = _telaPedidos;
            this.telaMesa = _telaMesa;
            nomeEntidade = "Conta";
            sufixo = "s";

        }
        protected override void MostrarTabela(ArrayList registros)
        {
            const string FORMATO_TABELA = "{0, -8} | {1, -10} | {2, -10} | {3}";
            Console.WriteLine(FORMATO_TABELA, "IdConta", "IdPedido", "Qntd", "ValorTotal");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Conta conta in registros)
            {
                Console.WriteLine(FORMATO_TABELA, conta.id, conta.pedido.id, conta.pedido.quantidade, "R$"+conta.valorTotal);
            }
        }
        protected override EntidadeBase ObterRegistro()
        {
            Pedido pedido = ObterPedido();
            Mesa mesa = ObterMesa();
            return new Conta(pedido, mesa);
        }
        private Pedido ObterPedido()
        {
            telaPedidos.VisualizarRegistros(true);
            Console.Write("\nDigite o id do pedido: ");
            int idPedido = Convert.ToInt32(Console.ReadLine());
            Pedido pedidos = repositorioPedidos.SelecionarPorId(idPedido);
            Console.WriteLine();
            return pedidos;
        }
        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(true);
            Console.Write("\nDigite o id da mesa: ");
            int idMesa = Convert.ToInt32(Console.ReadLine());
            Mesa mesa = repositorioMesa.SelecionarPorId(idMesa);
            Console.WriteLine();
            return mesa;
        }
    }
}
