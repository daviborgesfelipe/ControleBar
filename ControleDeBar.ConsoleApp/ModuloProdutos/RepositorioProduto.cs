using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloProdutos
{
    public class RepositorioProduto : RepositorioBase<Produto>
    {
        public RepositorioProduto(List<Produto> lista)
        {
            this.listaRegistros = lista;
        }
        public override Produto SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }
    }
}
