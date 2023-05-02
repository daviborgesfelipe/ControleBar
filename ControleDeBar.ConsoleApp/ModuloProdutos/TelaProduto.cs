using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloProdutos
{
    public class TelaProduto : TelaBase
    {
        public TelaProduto(RepositorioProduto _repositorioProduto)
        {
            this.repositorioBase = _repositorioProduto;
            nomeEntidade = "Produto";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2}", "Id", "Nome", "Valor");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Produtos produto in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2}", produto.id, produto.nome, produto.valor);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o valor: ");
            int valor = Convert.ToInt32(Console.ReadLine());
            return new Produtos(nome, valor);
        }
    }
}
