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
    public class TelaMesa : TelaBase
    {
        public TelaMesa(RepositorioMesa _repositorioMesa)
        {
            this.repositorioBase = _repositorioMesa;
            nomeEntidade = "Mesa";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1}", "Id", "Numero");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Mesa mesa in registros)
            {
                Console.WriteLine("{0, -10} | {1}", mesa.id, mesa.numero);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o numero: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            return new Mesa(numero);
        }
    }
}
