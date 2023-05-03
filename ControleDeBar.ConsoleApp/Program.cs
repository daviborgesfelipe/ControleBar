using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloPedidos;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            RepositorioGarcom _repositorioGarcom = new RepositorioGarcom(new ArrayList());
            RepositorioMesa _repositorioMesa = new RepositorioMesa(new ArrayList());
            RepositorioProduto _repositorioProduto = new RepositorioProduto(new ArrayList());
            RepositorioConta _repositorioConta = new RepositorioConta(new ArrayList());
            RepositorioPedido _repositorioPedido = new RepositorioPedido(new ArrayList());

            TelaProduto _telaProduto = new TelaProduto(_repositorioProduto);
            TelaGarcom _telaGarcom = new TelaGarcom(_repositorioGarcom);
            TelaPedido _telaPedido = new TelaPedido(
                _repositorioPedido, 
                _repositorioProduto,
                _telaProduto
                );
            TelaMesa _telaMesa = new TelaMesa(
                _repositorioMesa,
                _repositorioGarcom,
                _telaGarcom
                );
            TelaConta _telaConta = new TelaConta(
                _repositorioConta,
                _repositorioPedido,
                _repositorioMesa,
                _telaMesa,
                _telaPedido
                );

            program.CadastrarEntidades(
                _repositorioGarcom, 
                _repositorioMesa,
                _repositorioProduto,
                _repositorioPedido, 
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
                    int subMenu = _telaPedido.ApresentarMenu();

                    if (subMenu == 1)
                    {
                        _telaPedido.InserirNovoRegistro();
                    }
                    else if (subMenu == 2)
                    {
                        _telaPedido.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == 3)
                    {
                        _telaPedido.EditarRegistro();
                    }
                    else if (subMenu == 4)
                    {
                        _telaPedido.ExcluirRegistro();
                    }
                }
                else if (opcaoMenuInicial == 5)
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
                        _telaConta.EditarRegistro();
                    }
                    else if (subMenu == 4)
                    {
                        _telaConta.ExcluirRegistro();
                    }
                }
            }
        }

        public void CadastrarEntidades(
            RepositorioGarcom _repositorioGarcom,
            RepositorioMesa _repositorioMesa,
            RepositorioProduto _repositorioProduto,
            RepositorioPedido _repositorioPedido,
            RepositorioConta _repositorioConta
            )
        {
            Produto produtoUm = new Produto("Caipirinha", 10);
            Produto produtoDois = new Produto("Ovo Concerva", 2);
            Produto produtoTres = new Produto("Ficha sinuca", 0.5);
            Produto produtoQuatro = new Produto("Cerveja", 7);
            Produto produtoCinco = new Produto("Coca-cola", 6.5);
            Produto produtoSeis = new Produto("Batata-frita", 9.5);
            _repositorioProduto.Inserir(produtoUm);
            _repositorioProduto.Inserir(produtoDois);
            _repositorioProduto.Inserir(produtoTres);
            _repositorioProduto.Inserir(produtoQuatro);
            _repositorioProduto.Inserir(produtoCinco);
            _repositorioProduto.Inserir(produtoSeis);

            Pedido pedidoUm = new Pedido(produtoDois, 2);
            Pedido pedidoDois = new Pedido(produtoUm, 3);
            Pedido pedidoTres = new Pedido(produtoCinco, 3);
            Pedido pedidoQuatro = new Pedido(produtoTres, 3);
            Pedido pedidoCinco = new Pedido(produtoSeis, 3);
            _repositorioPedido.Inserir(pedidoUm);
            _repositorioPedido.Inserir(pedidoDois);
            _repositorioPedido.Inserir(pedidoTres);
            _repositorioPedido.Inserir(pedidoQuatro);
            _repositorioPedido.Inserir(pedidoCinco);


            Garcom garcomUm = new Garcom("Kelly Slater");
            Garcom garcomDois = new Garcom("Gabriel Medina");
            Garcom garcomTres = new Garcom("Chorão");
            Garcom garcomQuatro = new Garcom("Robo Tupiniquim");
            _repositorioGarcom.Inserir(garcomUm);
            _repositorioGarcom.Inserir(garcomDois);
            _repositorioGarcom.Inserir(garcomTres);
            _repositorioGarcom.Inserir(garcomQuatro);

            Mesa mesaUm = new Mesa(333, garcomQuatro);
            Mesa mesaDois = new Mesa(444, garcomDois);
            Mesa mesaTres = new Mesa(777, garcomUm);
            Mesa mesaQuatro = new Mesa(111, garcomTres);
            _repositorioMesa.Inserir(mesaUm);
            _repositorioMesa.Inserir(mesaDois);
            _repositorioMesa.Inserir(mesaTres);
            _repositorioMesa.Inserir(mesaQuatro);

            Conta contaUm = new Conta(pedidoUm, mesaDois);
            Conta contaDois = new Conta(pedidoDois, mesaUm);
            _repositorioConta.Inserir(contaUm);
            _repositorioConta.Inserir(contaDois);
        }

        public int ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Controle\n");

            Console.WriteLine("[1] Garçom");
            Console.WriteLine("[2] Mesa");
            Console.WriteLine("[3] Produto");
            Console.WriteLine("[4] Pedido");
            Console.WriteLine("[5] Conta\n");

            Console.WriteLine("Digite [S] para Sair");

            int opcao = Convert.ToInt32(Console.ReadLine());

            return opcao;
        }
    }
}