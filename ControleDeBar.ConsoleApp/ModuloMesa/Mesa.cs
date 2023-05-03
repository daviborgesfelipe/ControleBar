using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public int numero;
        public Garcom garcom;
        public Mesa(int numero, Garcom garcom)
        {
            this.numero = numero;
            this.garcom = garcom;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizado = (Mesa)registroAtualizado;
            this.numero = mesaAtualizado.numero;
            this.garcom = mesaAtualizado.garcom;
        }
        public void AdicionarGarcomNaMesa(Garcom garcom)
        {
            this.garcom = garcom;
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
    }
}
