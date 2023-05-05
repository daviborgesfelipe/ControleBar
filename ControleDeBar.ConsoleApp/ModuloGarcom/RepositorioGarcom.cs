using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class RepositorioGarcom : RepositorioBase<Garcom>
    {
        public RepositorioGarcom(List<Garcom> lista)
        {
            this.listaRegistros = lista;
        }
        public override Garcom SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }
    }
}
