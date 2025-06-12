using Academia_Programador_ClubeDaLeitura.Dados;
using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Apresentacao
{
    public class TelaMulta
    {
        private readonly RepositorioMulta repoMulta;
        private readonly RepositorioAmigo repoAmigo;

        public TelaMulta(RepositorioMulta repoMulta, RepositorioAmigo repoAmigo)
        {
            this.repoMulta = repoMulta;
            this.repoAmigo = repoAmigo;
        }

        public void ExibirMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Módulo de Multas ===");
                Console.WriteLine("1. Visualizar multas em aberto");
                Console.WriteLine("2. Quitar multa");
                Console.WriteLine("3. Visualizar multas por amigo");
                Console.WriteLine("4. Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": VisualizarPendentes(); break;
                    case "2": QuitarMulta(); break;
                    case "3": VisualizarPorAmigo(); break;
                    case "4": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void VisualizarPendentes()
        {
            Console.Clear();
            Console.WriteLine("--- Multas Pendentes ---");

            List<Multa> pendentes = repoMulta.SelecionarPendentes();

            if (pendentes.Count == 0)
            {
                Console.WriteLine("Nenhuma multa pendente.");
                return;
            }

            for (int i = 0; i < pendentes.Count; i++)
            {
                Console.WriteLine($"{i} - {pendentes[i]}");
            }
        }

        private void QuitarMulta()
        {
            VisualizarPendentes();

            Console.Write("Digite o número da multa para quitar: ");
            if (!int.TryParse(Console.ReadLine(), out int indice))
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            List<Multa> pendentes = repoMulta.SelecionarPendentes();
            if (indice < 0 || indice >= pendentes.Count)
            {
                Console.WriteLine("Multa não encontrada.");
                return;
            }

            pendentes[indice].Quitar();
            Console.WriteLine("Multa quitada com sucesso!");
        }

        private void VisualizarPorAmigo()
        {
            Console.Clear();
            Console.WriteLine("--- Multas por Amigo ---");

            List<Amigo> amigos = repoAmigo.SelecionarTodos();
            if (amigos.Count == 0)
            {
                Console.WriteLine("Nenhum amigo cadastrado.");
                return;
            }

            for (int i = 0; i < amigos.Count; i++)
                Console.WriteLine($"{i} - {amigos[i]}");

            Console.Write("Selecione o amigo: ");
            if (!int.TryParse(Console.ReadLine(), out int indiceAmigo) || indiceAmigo < 0 || indiceAmigo >= amigos.Count)
            {
                Console.WriteLine("Amigo inválido.");
                return;
            }

            Amigo amigoSelecionado = amigos[indiceAmigo];
            List<Multa> multas = repoMulta.SelecionarPorAmigo(amigoSelecionado);

            if (multas.Count == 0)
            {
                Console.WriteLine("Nenhuma multa registrada para este amigo.");
                return;
            }

            foreach (var multa in multas)
                Console.WriteLine(multa);
        }
    }
}
