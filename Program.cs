using Academia_Programador_ClubeDaLeitura.Apresentacao;
using Academia_Programador_ClubeDaLeitura.Dados;

namespace Academia_Programador_ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Repositórios
            RepositorioAmigo repositorioAmigo = new();
            RepositorioCaixa repositorioCaixa = new();
            RepositorioRevista repositorioRevista = new();
            RepositorioEmprestimo repositorioEmprestimo = new();
            RepositorioMulta repositorioMulta = new();
            RepositorioReserva repositorioReserva = new();

            // Telas (UI)
            TelaAmigo telaAmigo = new(repositorioAmigo);
            TelaCaixa telaCaixa = new(repositorioCaixa);
            TelaRevista telaRevista = new(repositorioRevista, repositorioCaixa);
            TelaMulta telaMulta = new(repositorioMulta, repositorioAmigo);
            TelaReserva telaReserva = new(repositorioReserva, repositorioAmigo, repositorioRevista, repositorioMulta);
            TelaEmprestimo telaEmprestimo = new(
                repositorioEmprestimo,
                repositorioAmigo,
                repositorioRevista,
                repositorioMulta,
                repositorioReserva
            );

            // Menu principal
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Clube da Leitura ===");
                Console.WriteLine("1. Módulo de Amigos");
                Console.WriteLine("2. Módulo de Caixas");
                Console.WriteLine("3. Módulo de Revistas");
                Console.WriteLine("4. Módulo de Empréstimos");
                Console.WriteLine("5. Módulo de Multas");
                Console.WriteLine("6. Módulo de Reservas");
                Console.WriteLine("7. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": telaAmigo.ExibirMenu(); break;
                    case "2": telaCaixa.ExibirMenu(); break;
                    case "3": telaRevista.ExibirMenu(); break;
                    case "4": telaEmprestimo.ExibirMenu(); break;
                    case "5": telaMulta.ExibirMenu(); break;
                    case "6": telaReserva.ExibirMenu(); break;
                    case "7":
                        Console.WriteLine("Encerrando aplicação...");
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


