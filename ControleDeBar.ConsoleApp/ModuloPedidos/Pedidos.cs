using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloPedidos
{
    public class Pedidos : EntidadeBase
    {
        public Produtos produtos;
        public double valorTotal;
        public Pedidos(Produtos produtos, double valorTotal)
        {
            this.produtos = produtos;
            this.valorTotal = valorTotal;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Pedidos produtoAtualizado = (Pedidos)registroAtualizado;

            this.produtos = produtoAtualizado.produtos;
            this.valorTotal = produtoAtualizado.valorTotal;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            return erros;
        }
    }
}
