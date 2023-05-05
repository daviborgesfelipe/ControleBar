namespace ControleDeBar.ConsoleApp.Compartilhado.Interface
{
    public interface ITelaBase
    {
        public int ApresentarMenu();
        public void InserirNovoRegistro();
        public void VisualizarRegistros(bool mostrarCabecalho);
        public void EditarRegistro();
        public void ExcluirRegistro();
    }
}
