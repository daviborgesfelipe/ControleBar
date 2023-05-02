using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloProdutos
{
    public class Produtos : EntidadeBase
    {
        public string nome;
        public double valor;
        public int qntd;
        public Produtos(string nome, double valor)
        {
            this.nome = nome;
            this.valor = valor;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produtos produtoAtualizado = (Produtos)registroAtualizado;

            this.nome = produtoAtualizado.nome;
            this.valor = produtoAtualizado.valor;
            this.qntd = produtoAtualizado.qntd;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            return erros;
        }
    }
}
