using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloCliente
{
    public class TelaCliente : TelaBase
    {
        public TelaCliente(RepositorioCliente _repositorioCliente)
        {
            this.repositorioBase = _repositorioCliente;
            nomeEntidade = "Cliente";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1}", "Id", "Numero");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Cliente cliente in registros)
            {
                Console.WriteLine("{0, -10} | {1}", cliente.id, cliente.nome);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o numero: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            return new ModuloMesa.Mesa(numero);
        }
    }
}
