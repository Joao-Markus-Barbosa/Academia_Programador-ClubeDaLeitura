using Academia_Programador_ClubeDaLeitura.Dados;
using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Apresentacao
{
    public class TelaRevista
    {
        private readonly RepositorioRevista repositorio;
        private readonly RepositorioCaixa repositorioCaixa;

        public TelaRevista(RepositorioRevista repositorio, RepositorioCaixa repositorioCaixa)
        {
            this.repositorio = repositorio;
            this.repositorioCaixa = repositorioCaixa;
        }

        public void ExibirMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Módulo de Revistas ===");
                Console.WriteLine("1. Inserir revista");
                Console.WriteLine("2. Editar revista");
                Console.WriteLine("3. Excluir revista");
                Console.WriteLine("4. Visualizar revistas");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": Inserir(); break;
                    case "2": Editar(); break;
                    case "3": Excluir(); break;
                    case "4": VisualizarTodos(); break;
                    case "5": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void Inserir()
        {
            Console.Clear();
            Console.WriteLine("--- Inserir Nova Revista ---");

            Revista nova = ObterRevistaPorEntrada();

            string resultado = nova.Validar();
            if (resultado != "VÁLIDO")
            {
                Console.WriteLine("Erro: " + resultado);
                return;
            }

            bool sucesso = repositorio.Inserir(nova);
            Console.WriteLine(sucesso ? "Revista cadastrada com sucesso!" : "Revista já existe.");
        }

        private void Editar()
        {
            Console.Clear();
            Console.WriteLine("--- Editar Revista ---");
            VisualizarTodos();

            Console.Write("Digite o número da revista para editar: ");
            if (!int.TryParse(Console.ReadLine(), out int indice))
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            Revista nova = ObterRevistaPorEntrada();
            string resultado = nova.Validar();

            if (resultado != "VÁLIDO")
            {
                Console.WriteLine("Erro: " + resultado);
                return;
            }

            bool sucesso = repositorio.Editar(indice, nova);
            Console.WriteLine(sucesso ? "Revista editada com sucesso!" : "Revista não encontrada.");
        }

        private void Excluir()
        {
            Console.Clear();
            Console.WriteLine("--- Excluir Revista ---");
            VisualizarTodos();

            Console.Write("Digite o número da revista para excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int indice))
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            bool sucesso = repositorio.Excluir(indice);
            Console.WriteLine(sucesso ? "Revista excluída com sucesso!" : "Falha ao excluir.");
        }

        private void VisualizarTodos()
        {
            Console.WriteLine("--- Lista de Revistas ---");
            List<Revista> lista = repositorio.SelecionarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma revista cadastrada.");
                return;
            }

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i} - {lista[i]}");
            }
        }

        private Revista ObterRevistaPorEntrada()
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Número da edição: ");
            int numeroEdicao = int.Parse(Console.ReadLine());

            Console.Write("Ano de publicação: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Selecione a caixa:");
            List<Caixa> caixas = repositorioCaixa.SelecionarTodos();
            for (int i = 0; i < caixas.Count; i++)
                Console.WriteLine($"{i} - {caixas[i]}");

            Console.Write("Digite o número da caixa: ");
            int indiceCaixa = int.Parse(Console.ReadLine());

            Caixa caixaSelecionada = repositorioCaixa.SelecionarPorIndice(indiceCaixa);

            return new Revista(titulo, numeroEdicao, ano, caixaSelecionada);
        }
    }
}
