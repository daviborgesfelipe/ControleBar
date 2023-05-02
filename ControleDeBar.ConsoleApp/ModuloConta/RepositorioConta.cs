using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase
    {
        public RepositorioConta(ArrayList _repositorioConta)
        {
            this.listaRegistros = _repositorioConta;
        }
        public override Conta SelecionarPorId(int id)
        {
            return (Conta)base.SelecionarPorId(id);
        }
    }
}
