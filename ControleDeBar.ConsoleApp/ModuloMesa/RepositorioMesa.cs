using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class RepositorioMesa : RepositorioBase
    {
        public RepositorioMesa(ArrayList listaMesa)
        {
            this.listaRegistros = listaMesa;
        }
        public override Mesa SelecionarPorId(int id)
        {
            return (Mesa)base.SelecionarPorId(id);
        }
    }
}
