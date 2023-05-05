using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.Compartilhado.Enums;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase<Conta>
    {
        public override Conta SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }
        public List<Conta> SelecionarContasEmAberto()
        {
            List<Conta> contasEmAberto = new List<Conta>();
            foreach (Conta conta in listaRegistros)
            {
                if (conta.status == StatusConta.Aberto)
                {
                    contasEmAberto.Add(conta);
                }
            }
            return contasEmAberto;
        }
        public List<Conta> SelecionarContasFechadas(DateTime data)
        {
            List<Conta> contasFechadas = new List<Conta>();
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
