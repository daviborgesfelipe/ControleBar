using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            RepositorioGarcom _repositorioGarcom = new RepositorioGarcom(new List<Garcom>());
            RepositorioMesa _repositorioMesa = new RepositorioMesa(new List<Mesa>());
            RepositorioProduto _repositorioProduto = new RepositorioProduto(new List<Produto>());
            RepositorioConta _repositorioConta = new RepositorioConta(new List<Conta>());

            TelaProduto _telaProduto = new TelaProduto(_repositorioProduto);
            TelaGarcom _telaGarcom = new TelaGarcom(_repositorioGarcom);
            TelaMesa _telaMesa = new TelaMesa(_repositorioMesa);
            TelaConta _telaConta = new TelaConta(
                _repositorioConta,
                _telaMesa,
                _telaGarcom,
                _telaProduto
                );

            program.CadastrarEntidades(
                _repositorioGarcom, 
                _repositorioMesa,
                _repositorioProduto,
                _repositorioConta
                );
            while (true) 
            {

                int opcaoMenuInicial = program.ApresentarMenu();

                if (opcaoMenuInicial == 1)
                {
                    int subMenu = _telaGarcom.ApresentarMenu();

                    if (subMenu == 1)
                    {
                        _telaGarcom.InserirNovoRegistro();
                    }
                    else if (subMenu == 2)
                    {
                        _telaGarcom.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == 3)
                    {
                        _telaGarcom.EditarRegistro();
                    }
                    else if (subMenu == 4)
                    {
                        _telaGarcom.ExcluirRegistro();
                    }
                }
                else if (opcaoMenuInicial == 2)
                {
                    int subMenu = _telaMesa.ApresentarMenu();

                    if (subMenu == 1)
                    {
                        _telaMesa.InserirNovoRegistro();
                    }
                    else if (subMenu == 2)
                    {
                        _telaMesa.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == 3)
                    {
                        _telaMesa.EditarRegistro();
                    }
                    else if (subMenu == 4)
                    {
                        _telaMesa.ExcluirRegistro();
                    }
                }
                else if (opcaoMenuInicial == 3)
                {
                    int subMenu = _telaProduto.ApresentarMenu();

                    if (subMenu == 1)
                    {
                        _telaProduto.InserirNovoRegistro();
                    }
                    else if (subMenu == 2)
                    {
                        _telaProduto.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == 3)
                    {
                        _telaProduto.EditarRegistro();
                    }
                    else if (subMenu == 4)
                    {
                        _telaProduto.ExcluirRegistro();
                    }
                }
                else if (opcaoMenuInicial == 4)
                {
                    int subMenu = _telaConta.ApresentarMenu();

                    if (subMenu == 1)
                    {
                        _telaConta.InserirNovoRegistro();
                    }
                    else if (subMenu == 2)
                    {
                        _telaConta.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == 3)
                    {
                        // registrar pedidos
                        _telaConta.RegistrarPedidos();
                    }
                    else if (subMenu == 4)
                    {
                        // visualizar contas abertas
                        _telaConta.VisualizarContasAbertas();
                        Console.ReadLine();
                    }
                    else if (subMenu == 5)
                    {
                        // visualizar faturamento do dia
                        _telaConta.VisualizarFaturamentoDoDia();
                        Console.ReadLine();
                    }
                    else if (subMenu == 6)
                    {
                        _telaConta.FecharContar();
                    }
                }
            }
        }

        public void CadastrarEntidades(
            RepositorioGarcom _repositorioGarcom,
            RepositorioMesa _repositorioMesa,
            RepositorioProduto _repositorioProduto,
            RepositorioConta _repositorioConta
            )
        {
            Produto produtoUm = new Produto("Caipirinha", 10.00M);
            Produto produtoDois = new Produto("Ovo Concerva", 2.00M);
            Produto produtoTres = new Produto("Ficha sinuca", 0.50M);
            Produto produtoQuatro = new Produto("Cerveja", 7.00M);
            Produto produtoCinco = new Produto("Coca-cola", 6.50M);
            Produto produtoSeis = new Produto("Batata frita", 9.50M);
            Produto produtoSete = new Produto("Agua", 2.50M);
            _repositorioProduto.Inserir(produtoUm);
            _repositorioProduto.Inserir(produtoDois);
            _repositorioProduto.Inserir(produtoTres);
            _repositorioProduto.Inserir(produtoQuatro);
            _repositorioProduto.Inserir(produtoCinco);
            _repositorioProduto.Inserir(produtoSeis);
            _repositorioProduto.Inserir(produtoSete);

            Pedido pedidoUm = new Pedido(produtoDois, 2);
            Pedido pedidoDois = new Pedido(produtoUm, 3);
            Pedido pedidoTres = new Pedido(produtoCinco, 5);
            Pedido pedidoQuatro = new Pedido(produtoTres, 14);
            Pedido pedidoCinco = new Pedido(produtoSeis, 3);
            Pedido pedidoSeis = new Pedido(produtoQuatro, 2);

            Garcom garcomUm = new Garcom("Kelly Slater");
            Garcom garcomDois = new Garcom("Gabriel Medina");
            Garcom garcomTres = new Garcom("Chorão");
            Garcom garcomQuatro = new Garcom("Robo Tupiniquim");
            _repositorioGarcom.Inserir(garcomUm);
            _repositorioGarcom.Inserir(garcomDois);
            _repositorioGarcom.Inserir(garcomTres);
            _repositorioGarcom.Inserir(garcomQuatro);

            Mesa mesaUm = new Mesa("333");
            Mesa mesaDois = new Mesa("444");
            Mesa mesaTres = new Mesa("777");
            Mesa mesaQuatro = new Mesa("111");
            _repositorioMesa.Inserir(mesaUm);
            _repositorioMesa.Inserir(mesaDois);
            _repositorioMesa.Inserir(mesaTres);
            _repositorioMesa.Inserir(mesaQuatro);

            Conta contaUm = new Conta(mesaTres, garcomUm, DateTime.Now);
            contaUm.RegistrarPedido(produtoCinco, 3);
            contaUm.RegistrarPedido(produtoDois, 7);
            contaUm.PagarConta();
            Conta contaDois = new Conta(mesaQuatro, garcomDois, DateTime.Now);
            contaDois.RegistrarPedido(produtoDois, 4);
            contaDois.RegistrarPedido(produtoQuatro, 1);
            Conta contaTres = new Conta(mesaTres, garcomTres, DateTime.Now);
            contaTres.RegistrarPedido(produtoSete, 2);
            contaTres.RegistrarPedido(produtoSeis, 4);
            Conta contaQuatro = new Conta(mesaUm, garcomQuatro, DateTime.Now);
            contaQuatro.RegistrarPedido(produtoUm, 3);
            contaQuatro.RegistrarPedido(produtoSeis, 3);
            contaQuatro.PagarConta();
            Conta contaCinco = new Conta(mesaDois, garcomTres, DateTime.Now);
            contaCinco.RegistrarPedido(produtoUm, 3);
            contaCinco.RegistrarPedido(produtoDois, 3);
            contaCinco.RegistrarPedido(produtoUm, 1);
            contaCinco.RegistrarPedido(produtoSete, 2);
            contaCinco.RegistrarPedido(produtoUm, 1);
            contaCinco.RegistrarPedido(produtoSeis, 3);
            _repositorioConta.Inserir(contaUm);
            _repositorioConta.Inserir(contaDois);
            _repositorioConta.Inserir(contaTres);
            _repositorioConta.Inserir(contaQuatro);
            _repositorioConta.Inserir(contaCinco);
        }

        public int ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Controle\n");

            Console.WriteLine("[1] Garçom");
            Console.WriteLine("[2] Mesa");
            Console.WriteLine("[3] Produto");
            Console.WriteLine("[4] Conta\n");

            Console.WriteLine("Digite [0] para Sair");

            int opcao = Convert.ToInt32(Console.ReadLine());

            return opcao;
        }
    }
}