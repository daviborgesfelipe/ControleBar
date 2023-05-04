using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string nome;
        public Garcom(string nome)
        {
            this.nome = nome;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Garcom garcomAtualizado = (Garcom)registroAtualizado;
            this.nome = garcomAtualizado.nome;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();
            if (string.IsNullOrEmpty(nome.Trim()))
            {
                erros.Add("O campo \"nome\" é obrigatório");
            }
            return erros;
        }
    }
}
