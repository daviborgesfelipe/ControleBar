using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.Compartilhado.Enums;
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
                if (conta.status == StatusConta.Aberto)
                {
                    contasEmAberto.Add(conta);
                }
            }
            return contasEmAberto;
        }
        public ArrayList SelecionarContasFechadas(DateTime data)
        {
            ArrayList contasFechadas = new ArrayList();

            foreach (Conta conta in listaRegistros)
            {
                if (conta.status == StatusConta.Pago && conta.data.Date == data.Date)
                {
                    contasFechadas.Add(conta);
                }
            }
            return contasFechadas;
        }
    }
}
