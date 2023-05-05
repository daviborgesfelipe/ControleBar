using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase<Mesa, RepositorioMesa>
    {

        public TelaMesa(RepositorioMesa _repositorioMesa)
        {
            this.repositorioBase = _repositorioMesa;
            nomeEntidade = "Mesa";
            sufixo = "s";
        }
        protected override void MostrarTabela(List<Mesa> registros)
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
                    mesa.status
                    );
            }
        }
        protected override Mesa ObterRegistro()
        {
            Console.Write($"Digite o numero da mesa: ");
            string numero = Console.ReadLine();
            Console.WriteLine();
            return new Mesa(numero);
        }
    }
}
