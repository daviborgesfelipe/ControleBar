
namespace ControleDeBar.ConsoleApp.Compartilhado.Interface
{
    public interface IRepositorioBase<IEntidadeBase>
    {
        public  void Inserir(IEntidadeBase registro);
        public void Editar(int id, IEntidadeBase registroAtualizado);
        public void Editar(IEntidadeBase registroSelecionado, IEntidadeBase registroAtualizado);
        public void Excluir(int id);
        public void Excluir(IEntidadeBase registroSelecionado);
        public IEntidadeBase SelecionarPorId(int id);
        public List<IEntidadeBase> SelecionarTodos();
        public bool TemRegistros();
    }
}
