using Academia_Programador_ClubeDaLeitura.Dados;
using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Apresentacao
{
    public class TelaAmigo
    {
        private readonly RepositorioAmigo repositorio;

        public TelaAmigo(RepositorioAmigo repositorio)
        {
            this.repositorio = repositorio;
        }

        public void ExibirMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Módulo de Amigos ===");
                Console.WriteLine("1. Inserir amigo");
                Console.WriteLine("2. Editar amigo");
                Console.WriteLine("3. Excluir amigo");
                Console.WriteLine("4. Visualizar amigos");
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

        public void Inserir()
        {
            Console.Clear();
            Console.WriteLine("--- Inserir Novo Amigo ---");

            Amigo novo = ObterAmigoPorEntrada();

            string resultadoValidacao = novo.Validar();
            if (resultadoValidacao != "VÁLIDO")
            {
                Console.WriteLine("Erro: " + resultadoValidacao);
                return;
            }

            bool sucesso = repositorio.Inserir(novo);
            Console.WriteLine(sucesso ? "Amigo cadastrado com sucesso!" : "Amigo já existe.");
        }

        public void Editar()
        {
            Console.Clear();
            Console.WriteLine("--- Editar Amigo ---");
            VisualizarTodos();

            Console.Write("Digite o número do amigo para editar: ");
            if (!int.TryParse(Console.ReadLine(), out int indice))
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            Amigo novo = ObterAmigoPorEntrada();
            string resultadoValidacao = novo.Validar();
            if (resultadoValidacao != "VÁLIDO")
            {
                Console.WriteLine("Erro: " + resultadoValidacao);
                return;
            }

            bool sucesso = repositorio.Editar(indice, novo);
            Console.WriteLine(sucesso ? "Amigo editado com sucesso!" : "Amigo não encontrado.");
        }

        public void Excluir()
        {
            Console.Clear();
            Console.WriteLine("--- Excluir Amigo ---");
            VisualizarTodos();

            Console.Write("Digite o número do amigo para excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int indice))
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            Amigo amigoSelecionado = repositorio.SelecionarPorIndice(indice);

            if (amigoSelecionado == null)
            {
                Console.WriteLine("Amigo não encontrado.");
                return;
            }

            if (repositorio.PossuiEmprestimosVinculados(amigoSelecionado))
            {
                Console.WriteLine("Não é possível excluir: amigo possui empréstimos ativos.");
                return;
            }

            bool sucesso = repositorio.Excluir(indice);
            Console.WriteLine(sucesso ? "Amigo excluído com sucesso!" : "Falha ao excluir.");
        }

        public void VisualizarTodos()
        {
            Console.WriteLine("--- Lista de Amigos ---");
            List<Amigo> lista = repositorio.SelecionarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum amigo cadastrado.");
                return;
            }

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i} - {lista[i]}");
            }
        }

        private Amigo ObterAmigoPorEntrada()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Responsável: ");
            string responsavel = Console.ReadLine();

            Console.Write("Telefone (formato (XX) XXXXX-XXXX): ");
            string telefone = Console.ReadLine();

            return new Amigo(nome, responsavel, telefone);
        }
    }
}

