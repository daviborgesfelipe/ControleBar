using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.Compartilhado.Enums;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProdutos;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta<TConta> : TelaBase<Conta>
    {
        RepositorioConta repositorioConta;
        TelaMesa<Mesa> telaMesa;
        TelaGarcom<Garcom> telaGarcom;
        TelaProduto<Produto> telaProduto;

        public TelaConta(
            RepositorioConta _repositorioConta,
            TelaMesa<Mesa> _telaMesa,
            TelaGarcom<Garcom> _telaGarcom,
            TelaProduto<Produto> _telaProduto
            )
        {
            this.repositorioBase = _repositorioConta;
            this.repositorioConta = _repositorioConta;
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
        internal void FecharContar()
        {
            MostrarCabecalho(
                $"Cadastro de {nomeEntidade}{sufixo}",
                $"Fechando {nomeEntidade}..."
                );
            Conta conta = ObterConta();
            conta.PagarConta();
            MostrarMensagem(
                $"{nomeEntidade} paga com sucesso!",
                ConsoleColor.DarkGreen
                );
        }
        internal bool VisualizarContasAbertas()
        {
            MostrarCabecalho(
                $"Cadastro de {nomeEntidade}{sufixo}",
                "Visualizando contas em aberto..."
                );
            List<Conta> contasEmAberto = repositorioConta.SelecionarContasEmAberto();
            if (contasEmAberto.Count == 0)
            {
                MostrarMensagem(
                    "Nenhuma conta em aberto",
                    ConsoleColor.DarkYellow
                    );
                return false;
            }
            MostrarTabela(contasEmAberto);
            return contasEmAberto.Count > 0;
        }
        internal void RegistrarPedidos()
        {
            MostrarCabecalho(
                $"Cadastro de {nomeEntidade}{sufixo}",
                "Registrando pedidos..."
                );
            bool temContasEmAberto = VisualizarContasAbertas();
            if (temContasEmAberto == false)
            {
                return;
            }
            Conta contaSelecionada = EncontrarEntidade("Digite o id da Conta: ");
            Console.WriteLine("[1] Adicionar pedidos");
            Console.WriteLine("[2] Remover pedidos");
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
        internal void VisualizarFaturamentoDoDia()
        {
            MostrarCabecalho(
                $"Cadastro de {nomeEntidade}{sufixo}",
                "Visualizando faturamento do dia..."
                );
            Console.WriteLine("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());
            List<Conta> contasFechadasNoDia = repositorioConta.SelecionarContasFechadas(data);
            FaturamentoDiario faturamentoDiario = new FaturamentoDiario(contasFechadasNoDia);
            decimal totalFaturado = faturamentoDiario.CalcularTotal();
            Console.WriteLine("Contas fechadas na data: " + data.ToShortDateString());
            MostrarTabela(contasFechadasNoDia);
            Console.WriteLine();
            MostrarMensagem(
                "Total faturado: " + totalFaturado,
                ConsoleColor.DarkGreen);
        }

        protected override Conta ObterRegistro()
        {
            Mesa mesa = ObterMesa();
            Garcom garcom = ObterGarcom();
            DateTime dataAbertura = ObterDataAbertura();
            Conta conta = new Conta(mesa, garcom, dataAbertura);
            return conta;
        }
        protected override void MostrarTabela(List<Conta> registros)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------\n");
            foreach (Conta conta in registros)
            {
                const string FORMATO_TABELA_CONTA = "{0, -10} | {1, -14} | {2, -25} |";
                const string FORMATO_TABELA_PEDIDO = "{0, -10} | {1, -40} | {2, -10} | {3}";
                const string FORMATO_TABELA_RODAPE = "{0, -55} | {1}";
                Console.Write(FORMATO_TABELA_CONTA, $" Conta: {conta.id}", $" Mesa: {conta.mesa.numero}", $" Garçom: {conta.garcom.nome}");
                if (conta.status == StatusConta.Aberto)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine($" Status: {conta.status}");
                Console.ResetColor();
                foreach (Pedido pedido in conta.pedidos)
                {
                    Console.WriteLine(FORMATO_TABELA_PEDIDO, $" {null}", $"\tProduto: {pedido.produto.nome}", $" Qtd: {pedido.quantidade}", $"Total: R${pedido.SomarValoresDosPedidos()}");
                }
                Console.WriteLine(FORMATO_TABELA_RODAPE, $"{null}", $" TotalConta: R${conta.CalcularValorTotal()}");
                Console.WriteLine("--------------------------------------------------------------------------------------\n");
            }
        }

        private void AdicionarPedidos(Conta contaSelecionada)
        {
            MostrarMensagem(
                "Selecionar produtos? [S] ou [N]",
                ConsoleColor.White
                );
            MostrarMensagem(
                " -> ",
                ConsoleColor.White
                );
            string opcao = Console.ReadLine();
            while (opcao == "s" || opcao == "S" || opcao == "Sim" || opcao == "SIM" || opcao == "sim")
            {
                Produto produto = ObterProduto();
                MostrarMensagem(
                    "Digite a quantidade: ",
                    ConsoleColor.White
                    );
                int quantidade = Convert.ToInt32(Console.ReadLine());
                contaSelecionada.RegistrarPedido(produto, quantidade);
                MostrarMensagem(
                    "Selecionar mais produtos? [S] ou [N]",
                    ConsoleColor.White
                    );
                MostrarMensagem(
                    " -> ",
                    ConsoleColor.White
                    );
                opcao = Console.ReadLine();
            }
        }
        private void RemoverPedidos(Conta contaSelecionada)
        {
            int id = 0;
            if (contaSelecionada.pedidos.Count == 0)
            {
                MostrarMensagem(
                    "Nenhum pedido cadastrado para esta conta",
                    ConsoleColor.DarkYellow
                    );
                return;
            }
        }
        private DateTime ObterDataAbertura()
        {
            Console.WriteLine("Digite a data: ");
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());
            return dataAbertura;
        }
        private Conta ObterConta()
        {
            VisualizarRegistros(false);
            Conta conta = EncontrarEntidade("Digite o id da Conta: ");
            Console.WriteLine();
            return conta;
        }
        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);
            Mesa mesa = telaMesa.EncontrarEntidade("Digite o id da Mesa: ");
            Console.WriteLine();
            return mesa;
        }
        private Garcom ObterGarcom()
        {
            telaGarcom.VisualizarRegistros(false);
            Garcom garcom = telaGarcom.EncontrarEntidade("Digite o id do Garçom: ");
            Console.WriteLine();
            return garcom;
        }
        private Produto ObterProduto()
        {
            telaProduto.VisualizarRegistros(false);
            Produto produto = telaProduto.EncontrarEntidade("Digite o id do Produto: ");
            Console.WriteLine();
            return produto;
        }
    }
}
