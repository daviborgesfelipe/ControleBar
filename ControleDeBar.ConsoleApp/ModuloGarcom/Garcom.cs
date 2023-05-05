using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase<Garcom>
    {
        public string nome;
        public Garcom(string nome)
        {
            this.nome = nome;
        }
        public override void AtualizarInformacoes(Garcom garcomAtualizado)
        {
            this.nome = garcomAtualizado.nome;
        }
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
            if (string.IsNullOrEmpty(nome.Trim()))
            {
                erros.Add("O campo \"nome\" é obrigatório");
            }
            return erros;
        }
    }
}
