using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {
        public string nome;

        public Funcionario(string nome)
        {
            this.nome = nome;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Funcionario funcionarioAtualizado = (Funcionario)registroAtualizado;

            this.nome = funcionarioAtualizado.nome;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome))
                erros.Add("O campo \"nome\" é obrigatório");

            return erros;
        }
    }
}
