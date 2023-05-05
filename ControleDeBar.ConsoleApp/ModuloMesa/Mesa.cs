using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.Compartilhado.Enums;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase<Mesa>
    {
        public string numero;
        public StatusMesa status;
        public Mesa(string numero)
        {
            this.status = StatusMesa.Disponivel;
            this.numero = numero;
        }
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
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

        public override void AtualizarInformacoes(Mesa mesaAtualizada)
        {
            this.numero = mesaAtualizada.numero;
        }
    }
}
