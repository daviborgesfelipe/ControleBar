using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class TelaGarcom : TelaBase
    {
        RepositorioGarcom repositorioGarcom;

        public TelaGarcom(RepositorioGarcom _repositorioGarcom)
        {
            this.repositorioBase = _repositorioGarcom;
            this.repositorioGarcom = _repositorioGarcom;
            nomeEntidade = "Garçom";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            const string FORMATO_TABELA = "| {0, -8} | {1, -20} |";
            Console.WriteLine(FORMATO_TABELA, "IdGarcom", "Nome");
            Console.WriteLine("-----------------------------------");
            foreach (Garcom garcom in registros)
            {
                Console.WriteLine(
                    FORMATO_TABELA,
                    garcom.id,
                    garcom.nome);
            }
        }
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write($"Digite o nome do garçom: ");
            string nome = Console.ReadLine();
            return new Garcom(nome);
        }

    }
}
