using System.Collections;

namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public abstract class TelaBase <T> where T : EntidadeBase
    {
        public string nomeEntidade;
        public string sufixo;

        protected RepositorioBase<T> repositorioBase = null;

        public void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();
            Console.WriteLine(titulo + "\n");
            Console.WriteLine(subtitulo + "\n");
        }
        public void MostrarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
        public virtual int ApresentarMenu()
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
        public virtual void InserirNovoRegistro()
        {
            MostrarCabecalho(
                $"Cadastro de {nomeEntidade}{sufixo}",
                "Inserindo um novo registro..."
                );
            T registro = ObterRegistro();
            if (TemErrosDeValidacao(registro))
            {
                InserirNovoRegistro(); //chamada recursiva
                return;
            }
            repositorioBase.Inserir(registro);
            MostrarMensagem(
                $"Registro de {nomeEntidade} inserido com sucesso!",
                ConsoleColor.DarkGreen
                );
        }
        public virtual void VisualizarRegistros(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
            {
                MostrarCabecalho(
                    $"Cadastro de {nomeEntidade}{sufixo}",
                    $"Visualizando registros de {nomeEntidade}{sufixo} já cadastrados..."
                    );
            }
            List<T> registros = repositorioBase.SelecionarTodos();
            if (registros.Count == 0)
            {
                MostrarMensagem(
                    $"Nenhum registro de {nomeEntidade} cadastrado",
                    ConsoleColor.DarkYellow
                    );
            }
            MostrarTabela(registros);
        }
        public virtual void EditarRegistro()
        {
            MostrarCabecalho(
                $"Cadastro de {nomeEntidade}{sufixo}",
                "Editando um registro já cadastrado..."
                );
            VisualizarRegistros(false);
            Console.WriteLine();
            T registro = EncontrarEntidade($"Digite o id do registro de {nomeEntidade}: ");
            T registroAtualizado = ObterRegistro();
            if (TemErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();
                return;
            }
            repositorioBase.Editar(registro, registroAtualizado);
            MostrarMensagem(
                $"Registro de {nomeEntidade} editado com sucesso!",
                ConsoleColor.DarkGreen);
        }
        public virtual void ExcluirRegistro()
        {
            MostrarCabecalho(
                $"Cadastro de {nomeEntidade}{sufixo}",
                $"Excluindo um registro de {nomeEntidade} já cadastrado..."
                );
            VisualizarRegistros(false);
            Console.WriteLine();
            T registro = EncontrarEntidade("Digite o id do registro: ");
            repositorioBase.Excluir(registro);
            MostrarMensagem(
                $"Registro de {nomeEntidade} excluído com sucesso!",
                ConsoleColor.DarkGreen
                );
        }      
        public virtual T EncontrarEntidade(string textoCampo)
        {            
            bool idInvalido;
            T entidadeSelecionada = null;
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
                    MostrarMensagem(
                        "Id inválido, tente novamente",
                        ConsoleColor.DarkRed
                        );
                }
            } while (idInvalido);

            return entidadeSelecionada;
        }

        protected bool TemErrosDeValidacao(T registro)
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
        protected abstract T ObterRegistro();
        protected abstract void MostrarTabela(List<T> registros);
    }
}
