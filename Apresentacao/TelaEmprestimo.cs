using Academia_Programador_ClubeDaLeitura.Dados;
using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Apresentacao
{
    public class TelaEmprestimo
    {
        private readonly RepositorioEmprestimo repoEmprestimo;
        private readonly RepositorioAmigo repoAmigo;
        private readonly RepositorioRevista repoRevista;
        private readonly RepositorioMulta repoMulta;
        private readonly RepositorioReserva repoReserva;

        public TelaEmprestimo(
            RepositorioEmprestimo repoEmprestimo,
            RepositorioAmigo repoAmigo,
            RepositorioRevista repoRevista,
            RepositorioMulta repoMulta,
            RepositorioReserva repoReserva)
        {
            this.repoEmprestimo = repoEmprestimo;
            this.repoAmigo = repoAmigo;
            this.repoRevista = repoRevista;
            this.repoMulta = repoMulta;
            this.repoReserva = repoReserva;
        }

        public void ExibirMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Módulo de Empréstimos ===");
                Console.WriteLine("1. Registrar empréstimo");
                Console.WriteLine("2. Registrar devolução");
                Console.WriteLine("3. Visualizar empréstimos ativos");
                Console.WriteLine("4. Visualizar empréstimos concluídos");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": RegistrarEmprestimo(); break;
                    case "2": RegistrarDevolucao(); break;
                    case "3": Visualizar(true); break;
                    case "4": Visualizar(false); break;
                    case "5": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void RegistrarEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("--- Registrar Novo Empréstimo ---");

            Amigo amigo = SelecionarAmigo();
            if (amigo == null) return;

            if (repoMulta.AmigoTemMultaPendente(amigo))
            {
                Console.WriteLine("Este amigo possui multas pendentes. Não pode realizar novo empréstimo.");
                return;
            }

            if (repoEmprestimo.AmigoTemEmprestimoAberto(amigo))
            {
                Console.WriteLine("Este amigo já possui um empréstimo em aberto.");
                return;
            }

            Revista revista = SelecionarRevistaDisponivel();
            if (revista == null) return;

            // Verifica reserva ativa de outro usuário
            if (repoReserva.RevistaTemReservaAtiva(revista))
            {
                Reserva reservaAtiva = repoReserva.ObterReservaAtiva(revista, amigo);

                if (reservaAtiva == null)
                {
                    Console.WriteLine("Esta revista está reservada por outro amigo.");
                    return;
                }
                else
                {
                    reservaAtiva.Concluir();
                    Console.WriteLine("Reserva convertida em empréstimo.");
                }
            }

            Emprestimo emprestimo = new Emprestimo(amigo, revista);

            string resultado = emprestimo.Validar();
            if (resultado != "VÁLIDO")
            {
                Console.WriteLine("Erro: " + resultado);
                return;
            }

            revista.Emprestar();
            repoEmprestimo.Inserir(emprestimo);
            Console.WriteLine("Empréstimo registrado com sucesso!");
        }

        private void RegistrarDevolucao()
        {
            Console.Clear();
            Console.WriteLine("--- Registrar Devolução ---");

            List<Emprestimo> ativos = repoEmprestimo.SelecionarAtivos();

            if (ativos.Count == 0)
            {
                Console.WriteLine("Nenhum empréstimo em aberto.");
                return;
            }

            for (int i = 0; i < ativos.Count; i++)
                Console.WriteLine($"{i} - {ativos[i]}");

            Console.Write("Digite o número do empréstimo para registrar devolução: ");
            if (!int.TryParse(Console.ReadLine(), out int indice) || indice < 0 || indice >= ativos.Count)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            Emprestimo emprestimo = ativos[indice];
            emprestimo.RegistrarDevolucao();

            if (emprestimo.EstaAtrasado())
            {
                Multa multa = new Multa(emprestimo);
                repoMulta.Inserir(multa);
                Console.WriteLine($"⚠️ Empréstimo atrasado. Multa registrada: R$ {multa.Valor:F2}");
            }

            Console.WriteLine("Devolução registrada com sucesso.");
        }

        private void Visualizar(bool ativos)
        {
            Console.Clear();
            List<Emprestimo> lista = ativos ? repoEmprestimo.SelecionarAtivos() : repoEmprestimo.SelecionarConcluidos();
            Console.WriteLine(ativos ? "--- Empréstimos Ativos ---" : "--- Empréstimos Concluídos ---");

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum empréstimo encontrado.");
                return;
            }

            foreach (var emp in lista)
                Console.WriteLine(emp);
        }

        private Amigo SelecionarAmigo()
        {
            List<Amigo> amigos = repoAmigo.SelecionarTodos();
            if (amigos.Count == 0)
            {
                Console.WriteLine("Nenhum amigo cadastrado.");
                return null;
            }

            Console.WriteLine("Selecione o amigo:");
            for (int i = 0; i < amigos.Count; i++)
                Console.WriteLine($"{i} - {amigos[i]}");

            Console.Write("Número do amigo: ");
            if (!int.TryParse(Console.ReadLine(), out int indice) || indice < 0 || indice >= amigos.Count)
                return null;

            return repoAmigo.SelecionarPorIndice(indice);
        }

        private Revista SelecionarRevistaDisponivel()
        {
            List<Revista> revistas = repoRevista.SelecionarDisponiveis();
            if (revistas.Count == 0)
            {
                Console.WriteLine("Nenhuma revista disponível.");
                return null;
            }

            Console.WriteLine("Selecione a revista:");
            for (int i = 0; i < revistas.Count; i++)
                Console.WriteLine($"{i} - {revistas[i]}");

            Console.Write("Número da revista: ");
            if (!int.TryParse(Console.ReadLine(), out int indice) || indice < 0 || indice >= revistas.Count)
                return null;

            return repoRevista.SelecionarPorIndice(indice);
        }
    }
}



