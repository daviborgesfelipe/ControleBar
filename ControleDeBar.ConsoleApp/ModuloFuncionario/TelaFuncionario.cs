using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloPedidos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario : TelaBase
    {
        public TelaFuncionario(RepositorioPedido _repositorioFuncionario)
        {
            this.repositorioBase = _repositorioFuncionario;
            nomeEntidade = "Funcionario";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1}", "Id", "Nome");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Funcionario funcionario in registros)
            {
                Console.WriteLine("{0, -10} | {1}", funcionario.id, funcionario.nome);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            return new Garcom(nome);
        }
    }
}
