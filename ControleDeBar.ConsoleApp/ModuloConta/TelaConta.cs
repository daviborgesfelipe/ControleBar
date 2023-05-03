using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloPedidos;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        RepositorioMesa repositorioMesa;
        RepositorioPedido repositorioPedidos;
        RepositorioGarcom repositorioGarcom;
        RepositorioConta repositorioConta;
        TelaMesa telaMesa;
        TelaPedido telaPedidos;
        TelaGarcom telaGarcom;

        public TelaConta(
            RepositorioConta _repositorioConta,
            RepositorioPedido _repositorioPedidos,
            RepositorioMesa _repositorioMesa,
            RepositorioGarcom _repositorioGarcom,
            TelaMesa _telaMesa,
            TelaPedido _telaPedidos,
            TelaGarcom _telaGarcom
            )
        {
            this.repositorioBase = _repositorioConta;
            this.repositorioConta = _repositorioConta;
            this.repositorioPedidos = _repositorioPedidos;
            this.repositorioMesa = _repositorioMesa;
            this.repositorioGarcom = _repositorioGarcom;
            this.telaPedidos = _telaPedidos;
            this.telaMesa = _telaMesa;
            this.telaGarcom = _telaGarcom;
            nomeEntidade = "Conta";
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            const string FORMATO_TABELA = "| {0, -8} | {1, -10} | {2, -12} | {3, -10} | {4, -15} | {5, -10} | {6, -10} |";
            Console.WriteLine(FORMATO_TABELA, "IdConta", "IdPedido","ValorPedido","NumeroMesa","Garçom", "ValorConta", "Status");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            foreach (Conta conta in registros)
            {
                if (conta.pedidos.Count > 1)
                {
                    foreach (Pedido pedido in conta.pedidos)
                    {
                        Console.WriteLine(FORMATO_TABELA,
                            conta.id, 
                            pedido.id,
                            "R$" + pedido.produto.valor * pedido.quantidade, 
                            conta.mesa.numero, 
                            conta.mesa.garcom.nome,  
                            "R$" + conta.valorTotal, 
                            conta.status);
                    }
                }else
                {
                    Console.WriteLine(FORMATO_TABELA, 
                        conta.id, conta.pedido.id, 
                        "R$" + conta.pedido.produto.valor * conta.pedido.quantidade, 
                        conta.mesa.numero, 
                        conta.mesa.garcom.nome, 
                        "R$" + conta.valorTotal, 
                        conta.status);
                }
            }
        }
        protected override EntidadeBase ObterRegistro()
        {
            Pedido pedido = ObterPedido();
            Mesa mesa = ObterMesa();
            Garcom garcom = ObterGarcom();
            mesa.AdicionarGarcomNaMesa(garcom);
            Conta conta = new Conta(pedido, mesa);
            return conta;
        }
        private Pedido ObterPedido()
        {
            telaPedidos.VisualizarRegistros(false);
            Console.Write("\nDigite o id do pedido: ");
            int idPedido = Convert.ToInt32(Console.ReadLine());
            Pedido pedidos = repositorioPedidos.SelecionarPorId(idPedido);
            Console.WriteLine();
            return pedidos;
        }
        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);
            Console.Write("\nDigite o id da mesa: ");
            int idMesa = Convert.ToInt32(Console.ReadLine());
            Mesa mesa = repositorioMesa.SelecionarPorId(idMesa);
            Console.WriteLine();
            return mesa;
        }
        private Garcom ObterGarcom()
        {
            telaGarcom.VisualizarRegistros(false);
            Console.Write("\nDigite o id do garçom que atendeu a mesa: ");
            int idGarcom = Convert.ToInt32(Console.ReadLine());
            Garcom garcom = repositorioGarcom.SelecionarPorId(idGarcom);
            Console.WriteLine();
            return garcom;
        }

        internal void FecharContar()
        {
            Conta conta = ObterConta();
            conta.PagarConta();
            MostrarMensagem($"{nomeEntidade} paga com sucesso!", ConsoleColor.DarkGreen);
        }
        public virtual int ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");
            Console.WriteLine($"[1] - Inserir {nomeEntidade}");
            Console.WriteLine($"[2] - Visualizar {nomeEntidade}");
            Console.WriteLine($"[3] - Editar {nomeEntidade}");
            Console.WriteLine($"[4] - Excluir {nomeEntidade}");
            Console.WriteLine($"[5] - Pagar {nomeEntidade}\n");
            Console.WriteLine("Digite [S] para Sair");
            int opcao = Convert.ToInt32(Console.ReadLine());
            return opcao;
        }
        private Conta ObterConta()
        {
            VisualizarRegistros(false);
            int idConta = Convert.ToInt32(Console.ReadLine());
            Conta conta = repositorioConta.SelecionarPorId(idConta);
            return conta;
        }
    }
}
