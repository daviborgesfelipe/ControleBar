using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloPedidos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        TelaPedido telaPedidos;
        TelaMesa telaMesa;
        RepositorioPedido repositorioPedidos;
        RepositorioMesa repositorioMesa;

        public TelaConta(
            RepositorioConta _repositorioConta,
            RepositorioPedido _repositorioPedidos,
            RepositorioMesa _repositorioMesa,
            TelaPedido _telaPedidos,
            TelaMesa _telaMesa
            )
        {
            this.repositorioBase = _repositorioConta;
            this.repositorioPedidos = _repositorioPedidos;
            this.repositorioMesa = _repositorioMesa;
            this.telaPedidos = _telaPedidos;
            this.telaMesa = _telaMesa;
            nomeEntidade = "Conta";

        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1}", "Id", "Numero");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Conta conta in registros)
            {
                Console.WriteLine("{0, -10} | {1}", conta.id);
            }
        }
        protected override EntidadeBase ObterRegistro()
        {
            Pedidos pedido = ObterPedido();
            Mesa mesa = ObterMesa();
            return new Conta(pedido, mesa, pedido.valorTotal);
        }
        private Pedidos ObterPedido()
        {
            telaPedidos.VisualizarRegistros(false);
            Console.Write("\nDigite o id do pedido: ");
            int idPedido = Convert.ToInt32(Console.ReadLine());
            Pedidos pedidos = repositorioPedidos.SelecionarPorId(idPedido);
            Console.WriteLine();
            return pedidos;
        }
        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);
            Console.Write("\nDigite o id da mesa: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());
            Mesa funcionario = repositorioMesa.SelecionarPorId(idFuncionario);
            Console.WriteLine();
            return funcionario;
        }
    }
}
