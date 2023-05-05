using ControleDeBar.ConsoleApp.Compartilhado.Enums;
using ControleDeBar.ConsoleApp.Compartilhado.Interface;
using System.Collections;

namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public abstract class TelaBase<IEntidadeBase, IRepositorioBase> : ITelaBase
        where IEntidadeBase : EntidadeBase<IEntidadeBase>
        where IRepositorioBase : RepositorioBase<IEntidadeBase>
    {
        public string nomeEntidade;
        public string sufixo;

        protected IRepositorioBase<IEntidadeBase> repositorioBase = null;

        public void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();
            Console.WriteLine(titulo + "\n");
            Console.WriteLine(subtitulo + "\n");
        }
        public int ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");
            Console.WriteLine($"[1] - Inserir {nomeEntidade}");
            Console.WriteLine($"[2] - Visualizar {nomeEntidade}");
            Console.WriteLine($"[3] - Editar {nomeEntidade}");
            Console.WriteLine($"[4] - Excluir {nomeEntidade}\n");
            Console.WriteLine("Digite [S] para Sair");
            int opcao = Convert.ToInt32(Console.ReadLine());
            return opcao;
        }
        public void InserirNovoRegistro()
        {
            MostrarCabecalho(
                $"Cadastro de {nomeEntidade}{sufixo}",
                "Inserindo um novo registro..."
                );
            IEntidadeBase registro = ObterRegistro();
            if (TemErrosDeValidacao(registro))
            {
                InserirNovoRegistro(); //chamada recursiva
                return;
            }
            repositorioBase.Inserir(registro);
            MostrarMensagemSucesso($"Registro de {nomeEntidade} inserido com sucesso!");
        }
        public void VisualizarRegistros(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
            {
                MostrarCabecalho(
                    $"Cadastro de {nomeEntidade}{sufixo}",
                    $"Visualizando registros de {nomeEntidade}{sufixo} já cadastrados..."
                    );
            }
            List<IEntidadeBase> registros = repositorioBase.SelecionarTodos();
            if (registros.Count == 0)
            {
                MostrarMensagemAtencao($"Nenhum registro de {nomeEntidade} cadastrado");
            }
            MostrarTabela(registros);
        }
        public void EditarRegistro()
        {
            MostrarCabecalho(
                $"Cadastro de {nomeEntidade}{sufixo}",
                "Editando um registro já cadastrado..."
                );
            VisualizarRegistros(false);
            Console.WriteLine();
            IEntidadeBase registro = EncontrarEntidade($"Digite o id do registro de {nomeEntidade}: ");
            IEntidadeBase registroAtualizado = ObterRegistro();
            if (TemErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();
                return;
            }
            repositorioBase.Editar(registro, registroAtualizado);
            MostrarMensagemSucesso($"Registro de {nomeEntidade} editado com sucesso!");
        }
        public void ExcluirRegistro()
        {
            MostrarCabecalho(
                $"Cadastro de {nomeEntidade}{sufixo}",
                $"Excluindo um registro de {nomeEntidade} já cadastrado..."
                );
            VisualizarRegistros(false);
            Console.WriteLine();
            IEntidadeBase registro = EncontrarEntidade("Digite o id do registro: ");
            repositorioBase.Excluir(registro);
            MostrarMensagemSucesso($"Registro de {nomeEntidade} excluído com sucesso!");
        }      
        public virtual IEntidadeBase EncontrarEntidade(string textoCampo)
        {            
            bool idInvalido;
            IEntidadeBase entidadeSelecionada = null;
            do
            {
                idInvalido = false;
                Console.Write("\n" + textoCampo);
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());
                    entidadeSelecionada = repositorioBase.SelecionarPorId(id);
                    if (entidadeSelecionada == null)
                    {
                        idInvalido = true;
                    }
                }
                catch (FormatException)
                {
                    idInvalido = true;
                }
                if (idInvalido)
                {
                    MostrarMensagemErro("Id inválido, tente novamente");
                }
            } while (idInvalido);

            return entidadeSelecionada;
        }

        protected void MostrarMensagemSucesso(string mensagem)
        {
            MostrarMensagem(mensagem, StatusMensagem.Sucesso);
        }
        protected void MostrarMensagemAtencao(string mensagem)
        {
            MostrarMensagem(mensagem, StatusMensagem.Atencao);
        }
        protected void MostrarMensagemErro(string mensagem)
        {
            MostrarMensagem(mensagem, StatusMensagem.Erro);
        }
        protected void MostrarMensagem(string mensagem, StatusMensagem status)
        {
            Console.WriteLine();
            ConsoleColor cor;
            switch (status)
            {
                case StatusMensagem.Sucesso: cor = ConsoleColor.DarkGreen; break;
                case StatusMensagem.Erro: cor = ConsoleColor.DarkRed; break;
                case StatusMensagem.Atencao: cor = ConsoleColor.DarkYellow; break;
                default:
                    cor = ConsoleColor.White;
                    break;
            }
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
        protected bool TemErrosDeValidacao(IEntidadeBase registro)
        {
            bool temErros = false;
            List<string> erros = registro.Validar();
            if (erros.Count > 0)
            {
                temErros = true;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                foreach (string erro in erros)
                {
                    Console.WriteLine(erro);
                }
                Console.ResetColor();
                Console.ReadLine();
            }
            return temErros;
        }
        protected abstract IEntidadeBase ObterRegistro();
        protected abstract void MostrarTabela(List<IEntidadeBase> registros);
    }
}
