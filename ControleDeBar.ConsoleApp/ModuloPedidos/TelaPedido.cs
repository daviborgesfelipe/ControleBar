using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloPedidos
{
    public class TelaPedido : TelaBase
    {
        private RepositorioPedido repositorioPedido;
        private RepositorioProduto repositorioProduto;
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
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            const string FORMATO_TABELA = "| {0, -8} | {1, -10} | {2, -15} | {3, -10} | {4, -8} | {5, -10} |";
            Console.WriteLine(FORMATO_TABELA, "IdPedido", "IdProduto", "Produto", "Quantidade", "Valor", "ValorTotal");
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach (Pedido pedido in registros)
            {
                Console.WriteLine(
                    FORMATO_TABELA,
                    pedido.id,
                    pedido.produto.id,
                    pedido.produto.nome,
                    pedido.quantidade,
                    "R$" + pedido.produto.valor,
                    "R$" + pedido.produto.valor * pedido.quantidade
                    );
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Produto produto = ObterProduto();
            int quantidade = ObterQuantidade();
            return new Pedido(produto, quantidade);
        }
        private int ObterQuantidade()
        {
            Console.Write("\nDigite a quantidade do produto: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            return quantidade;
        }
        private Produto ObterProduto()
        {
            telaProduto.VisualizarRegistros(true);
            Console.Write("\nDigite o id do produto: ");
            int idProduto = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Produto produto = repositorioProduto.SelecionarPorId(idProduto);
            return produto;
        }
    }
}
