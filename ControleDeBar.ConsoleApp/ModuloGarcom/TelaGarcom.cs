using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class TelaGarcom : TelaBase
    {
        public TelaGarcom(RepositorioGarcom _repositorioGarcom)
        {
            this.repositorioBase = _repositorioGarcom;
            nomeEntidade = "Garçom";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1}", "Id", "Nome");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Garcom garcom in registros)
            {
                Console.WriteLine("{0, -10} | {1}", garcom.id, garcom.nome);
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
