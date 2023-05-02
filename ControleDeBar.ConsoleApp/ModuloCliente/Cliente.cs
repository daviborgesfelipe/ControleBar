using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloCliente
{
    public class Cliente : EntidadeBase
    {
        public string nome;
        public Cliente(string nome)
        {
            this.nome = nome;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Cliente clienteAtualizado = (Cliente)registroAtualizado;
            this.nome = clienteAtualizado.nome; 
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome))
                erros.Add("O campo \"nome\" é obrigatório");

            return erros;
        }

    }
}
