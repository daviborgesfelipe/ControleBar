using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase
    {
        RepositorioMesa repositorioMesa;
        RepositorioGarcom repositorioGarcom;
        TelaGarcom telaGarcom;

        public TelaMesa(
            RepositorioMesa _repositorioMesa,
            RepositorioGarcom _repositorioGarcom,
            TelaGarcom _telaGarcom)
        {
            this.repositorioBase = _repositorioMesa;
            this.repositorioMesa = _repositorioMesa;
            this.repositorioGarcom = _repositorioGarcom;
            this.telaGarcom = _telaGarcom;
            nomeEntidade = "Mesa";
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            const string FORMATO_TABELA = "{0, -5} | {1}";
            Console.WriteLine(FORMATO_TABELA, "Id", "Numero");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Mesa mesa in registros)
            {
                Console.WriteLine(FORMATO_TABELA, mesa.id, mesa.numero);
            }
        }
        private Garcom ObterGarcom()
        {
            telaGarcom.VisualizarRegistros(false);
            Console.Write("\nDigite o id do garçom: ");
            int idGarcom = Convert.ToInt32(Console.ReadLine());
            Garcom garcom = repositorioGarcom.SelecionarPorId(idGarcom);
            Console.WriteLine();
            return garcom;
        }
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o numero: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Garcom garcom = ObterGarcom();
            return new Mesa(numero, garcom);
        }
    }
}
