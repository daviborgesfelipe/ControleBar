using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloProdutos
{
    public class Produto : EntidadeBase
    {
        public string nome;
        public decimal valor;
        public Produto(string nome, decimal valor)
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
            {
                erros.Add("O campo \"nome\" é obrigatório");
            }
            if (valor == 0 || valor == null)
            {
                erros.Add("O campo \"valor\" é obrigatório");
            }

            return erros;
        }
    }
}
