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
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            const string FORMATO_TABELA = "{0, -5} | {1, -20} | {2}";
            Console.WriteLine(FORMATO_TABELA, "Id", "Nome", "Valor");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Produto produto in registros)
            {
                Console.WriteLine(FORMATO_TABELA, produto.id, produto.nome, produto.valor);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o valor: ");
            int valor = Convert.ToInt32(Console.ReadLine());
            return new Produto(nome, valor);
        }
    }
}
