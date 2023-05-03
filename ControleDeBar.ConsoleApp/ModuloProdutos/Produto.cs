using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloProdutos
{
    public class Produto : EntidadeBase
    {
        public string nome;
        public double valor;
        public Produto(string nome, double valor)
        {
            this.nome = nome;
            this.valor = valor;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produtoAtualizado = (Produto)registroAtualizado;

            this.nome = produtoAtualizado.nome;
            this.valor = produtoAtualizado.valor;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            return erros;
        }
    }
}
