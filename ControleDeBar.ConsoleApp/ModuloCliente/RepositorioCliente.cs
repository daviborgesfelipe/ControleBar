using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloCliente
{
    public class RepositorioCliente : RepositorioBase
    {
        public RepositorioCliente(ArrayList listaCliente)
        {
            this.listaRegistros = listaCliente;
        }
        public override Cliente SelecionarPorId(int id)
        {
            return (Cliente)base.SelecionarPorId(id);
        }
    }
}
