using ControleDeBar.ConsoleApp.Compartilhado.Interface;
using System.Collections;

namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public abstract class RepositorioBase<IEntidadeBase> : IRepositorioBase<IEntidadeBase>
        where IEntidadeBase : EntidadeBase<IEntidadeBase>
    {
        protected List<IEntidadeBase> listaRegistros;
        protected int contadorRegistros = 0;

        public virtual void Inserir(IEntidadeBase registro)
        {
            contadorRegistros++;
            registro.id = contadorRegistros;
            listaRegistros.Add(registro);
        }
        public virtual void Editar(int id, IEntidadeBase registroAtualizado)
        {
            IEntidadeBase registroSelecionado = SelecionarPorId(id);
            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }
        public virtual void Editar(IEntidadeBase registroSelecionado, IEntidadeBase registroAtualizado)
        {
            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }
        public virtual void Excluir(int id)
        {
            IEntidadeBase registroSelecionado = SelecionarPorId(id);
            listaRegistros.Remove(registroSelecionado);
        }
        public virtual void Excluir(IEntidadeBase registroSelecionado)
        {
            listaRegistros.Remove(registroSelecionado);
        }
        public virtual IEntidadeBase SelecionarPorId(int id)
        {
            IEntidadeBase registroSelecionado = null;
            foreach (IEntidadeBase registro in listaRegistros)
            {
                if (registro.id == id)
                {
                    registroSelecionado = registro;
                    break;
                }
            }
            return registroSelecionado;
        }
        public virtual List<IEntidadeBase> SelecionarTodos()
        {
            return listaRegistros;
        }
        public bool TemRegistros()
        {
            return listaRegistros.Count > 0;
        }
    }
}
