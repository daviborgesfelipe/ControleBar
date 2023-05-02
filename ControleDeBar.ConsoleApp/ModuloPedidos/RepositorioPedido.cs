using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloPedidos
{
    public class RepositorioPedido : RepositorioBase
    {
        public RepositorioPedido(ArrayList _repositorioPedido)
        {
            this.listaRegistros = _repositorioPedido;
        }
        public override Pedidos SelecionarPorId(int id)
        {
            return (Pedidos)base.SelecionarPorId(id);
        }
    }
}
