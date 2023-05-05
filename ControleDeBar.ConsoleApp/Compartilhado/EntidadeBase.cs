using ControleDeBar.ConsoleApp.Compartilhado.Interface;
using System.Collections;

namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase<IEntidadeBase>
    {
        public int id;

        public abstract void AtualizarInformacoes(IEntidadeBase registroAtualizado);
        public abstract List<string> Validar();
        
    }
}