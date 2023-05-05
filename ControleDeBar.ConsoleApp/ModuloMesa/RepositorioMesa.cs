using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class RepositorioMesa : RepositorioBase<Mesa>
    {
        public RepositorioMesa(List<Mesa> lista)
        {
            this.listaRegistros = lista;
        }
        public override Mesa SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }
    }
}
