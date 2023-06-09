﻿using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.Compartilhado.Enums;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase<Conta>
    {
        public RepositorioConta(List<Conta> lista)
        {
                this.listaRegistros = lista;
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
