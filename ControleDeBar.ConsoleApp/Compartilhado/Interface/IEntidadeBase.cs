using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Compartilhado.Interface
{
    public interface IEntidadeBase
    {
        public void AtualizarInformacoes(IEntidadeBase registroAtualizado);
        public List<string> Validar();
    }
}
