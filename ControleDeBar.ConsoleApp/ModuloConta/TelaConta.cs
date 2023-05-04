using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        RepositorioMesa repositorioMesa;
        RepositorioGarcom repositorioGarcom;
        RepositorioConta repositorioConta;
        RepositorioProduto repositorioProduto;
        TelaMesa telaMesa;
        TelaGarcom telaGarcom;
        TelaProduto telaProduto;

        public TelaConta(
            RepositorioConta _repositorioConta,
            RepositorioMesa _repositorioMesa,
            RepositorioGarcom _repositorioGarcom,
            RepositorioProduto _repositorioProduto,
            TelaMesa _telaMesa,
            TelaGarcom _telaGarcom,
            TelaProduto _telaProduto
            )
        {
            this.repositorioBase = _repositorioConta;
            this.repositorioConta = _repositorioConta;
            this.repositorioMesa = _repositorioMesa;
            this.repositorioGarcom = _repositorioGarcom;
            this.repositorioProduto = _repositorioProduto;
            this.telaMesa = _telaMesa;
            this.telaGarcom = _telaGarcom;
            this.telaProduto = _telaProduto;
            nomeEntidade = "Conta";
            sufixo = "s";
        }
        internal virtual int ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");
            Console.WriteLine($"[1] - Inserir {nomeEntidade}");
            Console.WriteLine($"[2] - Visualizar {nomeEntidade}");
            Console.WriteLine($"[3] - Registrar Pedidos");
            Console.WriteLine($"[4] - Visualizar {nomeEntidade}{sufixo} abertas");
            Console.WriteLine($"[5] - Visualizar Faturamento do Dia");
            Console.WriteLine($"[6] - Fechar {nomeEntidade}\n");
            Console.WriteLine("Digite [S] para Sair");
            int opcao = Convert.ToInt32(Console.ReadLine());
            return opcao;
        }
        public bool VisualizarContasAbertas()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Visualizando contas em aberto...");
            ArrayList contasEmAberto = repositorioConta.SelecionarContasEmAberto();
            if (contasEmAberto.Count == 0)
            {
                MostrarMensagem("Nenhuma conta em aberto", ConsoleColor.DarkYellow);
                return false;
            }
            MostrarTabela(contasEmAberto);
            return contasEmAberto.Count > 0;
        }
        internal void FecharContar()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", $"Fechando {nomeEntidade}...");
            Conta conta = ObterConta();
            conta.PagarConta();
            MostrarMensagem($"{nomeEntidade} paga com sucesso!", ConsoleColor.DarkGreen);
        }
        public void RegistrarPedidos()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Registrando pedidos...");
            bool temContasEmAberto = VisualizarContasAbertas();
            if (temContasEmAberto == false)
            {
                return;
            }
            Conta contaSelecionada = (Conta)EncontrarRegistro("Digite o id da Conta: ");
            Console.WriteLine("Digite 1 para adicionar pedidos");
            Console.WriteLine("Digite 2 para remover pedidos");
            string opcao = Console.ReadLine();
            if (opcao == "1")
            {
                AdicionarPedidos(contaSelecionada);
            }
            else if (opcao == "2")
            {
                RemoverPedidos(contaSelecionada);
            }
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            foreach (Conta conta in registros)
            {
                Console.WriteLine("Conta: " + conta.id + ", Mesa: " + conta.mesa.numero + ", Garçom: " + conta.garcom.nome);
                Console.WriteLine();
                foreach (Pedido pedido in conta.pedidos)
                {
                    Console.WriteLine("\tProduto: " + pedido.produto.nome + ", Qtd: " + pedido.quantidade);
                }

                Console.WriteLine("------------------------------------------------------\n");
            }
        }
        protected override EntidadeBase ObterRegistro()
        {
            Mesa mesa = ObterMesa();
            Garcom garcom = ObterGarcom();
            DateTime dataAbertura = ObterDataAbertura();
            Conta conta = new Conta(mesa, garcom, dataAbertura);
            return conta;
        }

        private DateTime ObterDataAbertura()
        {
            MostrarMensagem("Digite a data: ", ConsoleColor.White);
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());
            return dataAbertura;
        }
        private Conta ObterConta()
        {
            VisualizarRegistros(false);
            Conta conta = (Conta)telaMesa.EncontrarRegistro("Digite o id da Conta");
            Console.WriteLine();
            return conta;
        }
        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);
            Mesa mesa = (Mesa)telaMesa.EncontrarRegistro("Digite o id da Mesa");
            Console.WriteLine();
            return mesa;
        }
        private Garcom ObterGarcom()
        {
            telaGarcom.VisualizarRegistros(false);
            Garcom garcom = (Garcom)telaGarcom.EncontrarRegistro("Digite o id do Garçom");
            Console.WriteLine();
            return garcom;
        }
        private Produto ObterProduto()
        {
            telaProduto.VisualizarRegistros(false);
            Produto produto = (Produto)telaProduto.EncontrarRegistro("Digite o id do Produto: ");
            Console.WriteLine();
            return produto;
        }

        private void AdicionarPedidos(Conta contaSelecionada)
        {
            Console.WriteLine("Selecionar produtos? [s] ou [n]");
            Console.Write(" -> ");
            string opcao = Console.ReadLine();
            while (opcao == "s")
            {
                Produto produto = ObterProduto();
                Console.Write("Digite a quantidade: ");
                int quantidade = Convert.ToInt32(Console.ReadLine());
                contaSelecionada.RegistrarPedido(produto, quantidade);
                Console.WriteLine("Selecionar mais produtos? [s] ou [n]");
                Console.Write(" -> ");
                opcao = Console.ReadLine();
            }
        }
        public void VisualizarFaturamentoDoDia()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Visualizando faturamento do dia...");
            Console.WriteLine("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());
            ArrayList contasFechadasNoDia = repositorioConta.SelecionarContasFechadas(data);
            FaturamentoDiario faturamentoDiario = new FaturamentoDiario(contasFechadasNoDia);
            decimal totalFaturado = faturamentoDiario.CalcularTotal();
            Console.WriteLine("Contas fechadas na data: " + data.ToShortDateString());
            MostrarTabela(contasFechadasNoDia);
            Console.WriteLine();
            MostrarMensagem("Total faturado: " + totalFaturado, ConsoleColor.Green);
        }

        private void RemoverPedidos(Conta contaSelecionada)
        {
            int id = 0;
            if (contaSelecionada.pedidos.Count == 0)
            {
                MostrarMensagem("Nenhum pedido cadastrado para esta conta", ConsoleColor.DarkYellow);
                return;
            }
        }
    }
}
