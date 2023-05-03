using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloPedidos
{
    public class RepositorioPedido : RepositorioBase
    {
        public RepositorioPedido(ArrayList _repositorioPedido)
        {
            this.listaRegistros = _repositorioPedido;
        }
        public override Pedido SelecionarPorId(int id)
        {
            return (Pedido)base.SelecionarPorId(id);
        }
    }
}
