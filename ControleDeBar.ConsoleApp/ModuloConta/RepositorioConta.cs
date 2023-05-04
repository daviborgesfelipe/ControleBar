using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

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
        public ArrayList SelecionarContasEmAberto()
        {
            ArrayList contasEmAberto = new ArrayList();

            foreach (Conta conta in listaRegistros)
            {
                if (conta.status == "Aberta")
                {
                    contasEmAberto.Add(conta);
                }
            }
            return contasEmAberto;
        }
        public ArrayList SelecionarContasFechadas(DateTime data)
        {
            ArrayList contasEmAberto = new ArrayList();

            foreach (Conta conta in listaRegistros)
            {
                if (conta.status == "Pago" && conta.data.Date == data.Date)
                {
                    contasEmAberto.Add(conta);
                }
            }
            return contasEmAberto;
        }
    }
}
