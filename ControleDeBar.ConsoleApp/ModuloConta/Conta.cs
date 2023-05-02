using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloPedidos;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Pedidos pedidos;
        public Mesa mesa;
        public double valorTotal;
        public Conta(Pedidos pedidos, Mesa mesa, double valorTotal)
        {
            this.pedidos = pedidos;
            this.mesa = mesa;
            this.valorTotal = valorTotal;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta produtoAtualizado = (Conta)registroAtualizado;

            this.pedidos = produtoAtualizado.pedidos;
            this.mesa = produtoAtualizado.mesa;
            this.valorTotal = produtoAtualizado.valorTotal;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (pedidos == null)
                erros.Add("O campo \"produtos\" é obrigatório");

            return erros;
        }
    }
}
