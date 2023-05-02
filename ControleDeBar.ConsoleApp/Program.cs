using ControleDeBar.ConsoleApp.ModuloCliente;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
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
            RepositorioCliente _repositorioCliente = new RepositorioCliente(new ArrayList());
            RepositorioPedido _repositorioPedido = new RepositorioPedido(new ArrayList());

            TelaGarcom _telaGarcom = new TelaGarcom(_repositorioGarcom);
            TelaMesa _telaMesa = new TelaMesa(_repositorioMesa);
            TelaProduto _telaProduto = new TelaProduto(_repositorioProduto);
            TelaCliente _telaCliente = new TelaCliente(_repositorioCliente);
            TelaPedido _telaPedido = new TelaPedido(
                _repositorioPedido, 
                _repositorioProduto,
                _telaProduto);
            TelaConta _telaConta = new TelaConta(
                _repositorioConta,
                _repositorioPedido,
                _repositorioMesa,
                _telaPedido,
                _telaMesa
                );

            program.CadastrarEntidades(
                _repositorioGarcom, 
                _repositorioMesa,
                _repositorioProduto,
                _repositorioCliente
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
                    int subMenu = _telaCliente.ApresentarMenu();

                    if (subMenu == 1)
                    {
                        _telaCliente.InserirNovoRegistro();
                    }
                    else if (subMenu == 2)
                    {
                        _telaCliente.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == 3)
                    {
                        _telaCliente.EditarRegistro();
                    }
                    else if (subMenu == 4)
                    {
                        _telaCliente.ExcluirRegistro();
                    }
                }
                else if (opcaoMenuInicial == 6)
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
            RepositorioCliente _repositorioCliente
            )
        {
            Mesa mesaUm = new Mesa(333);
            Mesa mesaDois = new Mesa(444);
            _repositorioMesa.Inserir(mesaUm);
            _repositorioMesa.Inserir(mesaDois);

            Cliente clienteUm = new Cliente("Strider");
            Cliente clienteDois = new Cliente("Carisa Moore");
            _repositorioCliente.Inserir(clienteUm);
            _repositorioCliente.Inserir(clienteDois);

            Garcom garcomUm = new Garcom("Kelly Slater");
            Garcom garcomDois = new Garcom("Gabriel Medina");
            _repositorioGarcom.Inserir(garcomUm);
            _repositorioGarcom.Inserir(garcomDois);

            Produtos produtoUm = new Produtos("Velho Barreiro", 10);
            Produtos produtoDois = new Produtos("Catuaba Selvagem", 15);
            _repositorioProduto.Inserir(produtoUm);
            _repositorioProduto.Inserir(produtoDois);
        }

        public int ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Controle\n");

            Console.WriteLine("[1] Garçom");
            Console.WriteLine("[2] Mesa");
            Console.WriteLine("[3] Produto");
            Console.WriteLine("[4] Pedido");
            Console.WriteLine("[5] Cliente");
            Console.WriteLine("[6] Conta");
            Console.WriteLine("[7] Funcionario\n");

            Console.WriteLine("Digite s para Sair");

            int opcao = Convert.ToInt32(Console.ReadLine());

            return opcao;
        }
    }
}