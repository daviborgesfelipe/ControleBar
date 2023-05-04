using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    internal class FaturamentoDiario
    {
        private ArrayList contasFechadas;
        public FaturamentoDiario(ArrayList contas)
        {
            this.contasFechadas = contas;
        }
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (Conta conta in contasFechadas)
            {
                total += conta.CalcularValorTotal();
            }
            return total;
        }
    }
}