using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloPedidos
{
    public class TelaPedido : TelaBase
    {
        private RepositorioProduto repositorioProduto;
        private RepositorioPedido repositorioPedido;
        private TelaProduto telaProduto;
        public TelaPedido(
            RepositorioPedido _repositorioPedido,
            RepositorioProduto _repositorioProduto,
            TelaProduto _telaProduto)
        {
            this.repositorioBase = _repositorioPedido;

            this.repositorioPedido = _repositorioPedido;
            this.repositorioProduto = _repositorioProduto;
            this.telaProduto = _telaProduto;
            nomeEntidade = "Pedido";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            const string FORMATO_TABELA = "{0, -10} | {1, -20} | {2}";

            Console.WriteLine(FORMATO_TABELA, "Id", "Produto Pedido", "Valor Total");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Pedidos pedidos in registros)
            {
                Console.WriteLine(FORMATO_TABELA,
                    pedidos.id,
                    pedidos.produtos.nome,
                    pedidos.valorTotal);

            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Produtos produto = ObterPedido();
            Console.Write("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            double valorTotal = produto.valor * quantidade;
            //Console.Write("Digite a data: ");
            //DateTime data = Convert.ToDateTime(Console.ReadLine());
            return new Pedidos(produto, valorTotal);
        }

        private Produtos ObterPedido()
        {
            telaProduto.VisualizarRegistros(false);
            Console.Write("\nDigite o id do produto: ");
            int idProduto = Convert.ToInt32(Console.ReadLine());
            Produtos pedido = repositorioProduto.SelecionarPorId(idProduto);
            Console.WriteLine();
            return pedido;
        }
    }
}
