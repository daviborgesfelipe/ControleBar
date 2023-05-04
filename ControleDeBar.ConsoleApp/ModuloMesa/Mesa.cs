using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.Compartilhado.Enums;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public int numero;
        public StatusMesa status;
        public Mesa(int numero)
        {
            this.numero = numero;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizado = (Mesa)registroAtualizado;
            this.numero = mesaAtualizado.numero;
        }
        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (this.numero == null)
            {
                erros.Add("O campo \"numero\" é obrigatório");
            }
            return erros;
        }

        public void Desocupar()
        {
            status = StatusMesa.Disponivel;
        }

        public void Ocupar()
        {
            status = StatusMesa.Ocupada;
        }
    }
}
