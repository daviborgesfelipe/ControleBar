using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.Compartilhado.Interface;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloProdutos
{
    public class Produto : EntidadeBase<Produto>
    {
        public string nome;
        public decimal valor;
        public Produto(string nome, decimal valor)
        {
            this.nome = nome;
            this.valor = valor;
        }
        public override void AtualizarInformacoes(Produto registroAtualizado)
        {
            this.nome = registroAtualizado.nome;
            this.valor = registroAtualizado.valor;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
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
