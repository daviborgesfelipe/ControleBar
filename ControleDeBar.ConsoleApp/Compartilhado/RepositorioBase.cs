using System.Collections;

namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public abstract class RepositorioBase<T> where T : EntidadeBase
    {
        protected List<T> listaRegistros;
        protected int contadorRegistros = 0;

        public RepositorioBase()
        {
            listaRegistros = new List<T>();
        }
        public virtual void Inserir(T registro)
        {
            contadorRegistros++;
            registro.id = contadorRegistros;
            listaRegistros.Add(registro);
        }

        public virtual void Editar(int id, T registroAtualizado)
        {
            T registroSelecionado = SelecionarPorId(id);
            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }

        public virtual void Editar( T registroSelecionado, T registroAtualizado)
        {
            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }

        public virtual void Excluir(int id)
        {
            T registroSelecionado = SelecionarPorId(id);
            listaRegistros.Remove(registroSelecionado);
        }

        public virtual void Excluir(T registroSelecionado)
        {
            listaRegistros.Remove(registroSelecionado);
        }

        public virtual T SelecionarPorId(int id)
        {
            T registroSelecionado = null;
            foreach (T registro in listaRegistros)
            {
                if (registro.id == id)
                {
                    registroSelecionado = registro;
                    break;
                }
            }
            return registroSelecionado;
        }

        public virtual List<T> SelecionarTodos()
        {
            return listaRegistros;
        }

        public bool TemRegistros()
        {
            return listaRegistros.Count > 0;
        }
    }
}
