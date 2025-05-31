using Academia_Programador_ClubeDaLeitura.Dados;
using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Apresentacao
{
    public class TelaCaixa
    {
        private readonly RepositorioCaixa repositorio;

        public TelaCaixa(RepositorioCaixa repositorio)
        {
            this.repositorio = repositorio;
        }

        public void ExibirMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Módulo de Caixas ===");
                Console.WriteLine("1. Inserir caixa");
                Console.WriteLine("2. Editar caixa");
                Console.WriteLine("3. Excluir caixa");
                Console.WriteLine("4. Visualizar caixas");
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
            Console.WriteLine("--- Inserir Nova Caixa ---");

            Caixa nova = ObterCaixaPorEntrada();

            string resultado = nova.Validar();
            if (resultado != "VÁLIDO")
            {
                Console.WriteLine("Erro: " + resultado);
                return;
            }

            bool sucesso = repositorio.Inserir(nova);
            Console.WriteLine(sucesso ? "Caixa cadastrada com sucesso!" : "Etiqueta já existe.");
        }

        private void Editar()
        {
            Console.Clear();
            Console.WriteLine("--- Editar Caixa ---");
            VisualizarTodos();

            Console.Write("Digite o número da caixa para editar: ");
            if (!int.TryParse(Console.ReadLine(), out int indice))
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            Caixa nova = ObterCaixaPorEntrada();

            string resultado = nova.Validar();
            if (resultado != "VÁLIDO")
            {
                Console.WriteLine("Erro: " + resultado);
                return;
            }

            bool sucesso = repositorio.Editar(indice, nova);
            Console.WriteLine(sucesso ? "Caixa editada com sucesso!" : "Caixa não encontrada.");
        }

        private void Excluir()
        {
            Console.Clear();
            Console.WriteLine("--- Excluir Caixa ---");
            VisualizarTodos();

            Console.Write("Digite o número da caixa para excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int indice))
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            Caixa caixaSelecionada = repositorio.SelecionarPorIndice(indice);
            if (caixaSelecionada == null)
            {
                Console.WriteLine("Caixa não encontrada.");
                return;
            }

            if (repositorio.PossuiRevistasVinculadas(caixaSelecionada))
            {
                Console.WriteLine("Não é possível excluir: caixa possui revistas vinculadas.");
                return;
            }

            bool sucesso = repositorio.Excluir(indice);
            Console.WriteLine(sucesso ? "Caixa excluída com sucesso!" : "Falha ao excluir.");
        }

        private void VisualizarTodos()
        {
            Console.WriteLine("--- Lista de Caixas ---");
            List<Caixa> lista = repositorio.SelecionarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma caixa cadastrada.");
                return;
            }

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i} - {lista[i]}");
            }
        }

        private Caixa ObterCaixaPorEntrada()
        {
            Console.Write("Etiqueta: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Cor (pode usar hexadecimal ou nome): ");
            string cor = Console.ReadLine();

            Console.Write("Dias de empréstimo (padrão 7): ");
            string diasInput = Console.ReadLine();
            int dias = string.IsNullOrWhiteSpace(diasInput) ? 7 : int.Parse(diasInput);

            return new Caixa(etiqueta, cor, dias);
        }
    }
}
