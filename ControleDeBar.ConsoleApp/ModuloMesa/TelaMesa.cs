using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase
    {

        public TelaMesa(RepositorioMesa _repositorioMesa)
        {
            this.repositorioBase = _repositorioMesa;
            nomeEntidade = "Mesa";
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            const string FORMATO_TABELA = "| {0, -8} | {1, -10} | {2, -20} |";
            Console.WriteLine(FORMATO_TABELA, "IdMesa", "NumeroMesa", "Ocupada");
            Console.WriteLine("------------------------------------------------");
            foreach (Mesa mesa in registros)
            {
                Console.WriteLine(
                    FORMATO_TABELA,
                    mesa.id,
                    mesa.numero,
                    mesa.ocupada
                    );
            }
        }
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write($"Digite o numero da mesa: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return new Mesa(numero);
        }
    }
}
