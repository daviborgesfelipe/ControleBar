using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloProdutos
{
    public class TelaProduto<TProduto> : TelaBase<Produto>
    {
        public TelaProduto(RepositorioProduto _repositorioProduto)
        {
            this.repositorioBase = _repositorioProduto;
            nomeEntidade = "Produto";
            sufixo = "s";
        }
        protected override void MostrarTabela(List<Produto> registros)
        {
            const string FORMATO_TABELA = "| {0, -9} | {1, -20} | {2, -8} |";
            Console.WriteLine(FORMATO_TABELA, "IdProduto", "Nome", "Valor");
            Console.WriteLine("-----------------------------------------------");
            foreach (Produto produto in registros)
            {
                Console.WriteLine(
                    FORMATO_TABELA,
                    produto.id,
                    produto.nome,
                    "R$"+produto.valor);
            }
        }
        protected override Produto ObterRegistro()
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o valor do produto: ");
            decimal valor = Convert.ToDecimal(Console.ReadLine());
            return new Produto(nome, valor);
        }
    }
}
