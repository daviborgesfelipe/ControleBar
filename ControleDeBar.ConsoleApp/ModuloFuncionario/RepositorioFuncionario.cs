using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloPedidos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase
    {
        public RepositorioFuncionario(ArrayList _repositorioFuncionario)
        {
            this.listaRegistros = _repositorioFuncionario;
        }
        public override Pedidos SelecionarPorId(int id)
        {
            return (Pedidos)base.SelecionarPorId(id);
        }
    }
}
