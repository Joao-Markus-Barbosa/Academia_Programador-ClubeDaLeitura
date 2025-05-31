using Academia_Programador_ClubeDaLeitura.Apresentacao;
using Academia_Programador_ClubeDaLeitura.Dados;

namespace Academia_Programador_ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instanciando repositórios
            RepositorioAmigo repositorioAmigo = new();
            RepositorioCaixa repositorioCaixa = new();
            RepositorioRevista repositorioRevista = new();
            RepositorioEmprestimo repositorioEmprestimo = new();

            // Instanciando telas
            TelaAmigo telaAmigo = new(repositorioAmigo);
            TelaCaixa telaCaixa = new(repositorioCaixa);
            TelaRevista telaRevista = new(repositorioRevista, repositorioCaixa);
            TelaEmprestimo telaEmprestimo = new(repositorioEmprestimo, repositorioAmigo, repositorioRevista);

            // Loop principal
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Clube da Leitura ===");
                Console.WriteLine("1. Módulo de Amigos");
                Console.WriteLine("2. Módulo de Caixas");
                Console.WriteLine("3. Módulo de Revistas");
                Console.WriteLine("4. Módulo de Empréstimos");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        telaAmigo.ExibirMenu();
                        break;
                    case "2":
                        telaCaixa.ExibirMenu();
                        break;
                    case "3":
                        telaRevista.ExibirMenu();
                        break;
                    case "4":
                        telaEmprestimo.ExibirMenu();
                        break;
                    case "5":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
