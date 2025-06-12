using Academia_Programador_ClubeDaLeitura.Dados;
using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Apresentacao
{
    public class TelaReserva
    {
        private readonly RepositorioReserva repoReserva;
        private readonly RepositorioAmigo repoAmigo;
        private readonly RepositorioRevista repoRevista;
        private readonly RepositorioMulta repoMulta;

        public TelaReserva(RepositorioReserva repoReserva, RepositorioAmigo repoAmigo, RepositorioRevista repoRevista, RepositorioMulta repoMulta)
        {
            this.repoReserva = repoReserva;
            this.repoAmigo = repoAmigo;
            this.repoRevista = repoRevista;
            this.repoMulta = repoMulta;
        }

        public void ExibirMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Módulo de Reservas ===");
                Console.WriteLine("1. Criar reserva");
                Console.WriteLine("2. Cancelar reserva");
                Console.WriteLine("3. Visualizar reservas ativas");
                Console.WriteLine("4. Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": CriarReserva(); break;
                    case "2": CancelarReserva(); break;
                    case "3": VisualizarReservas(); break;
                    case "4": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void CriarReserva()
        {
            Console.Clear();
            Console.WriteLine("--- Criar Reserva ---");

            Amigo amigo = SelecionarAmigo();
            if (amigo == null) return;

            if (repoMulta.AmigoTemMultaPendente(amigo))
            {
                Console.WriteLine("Amigo com multa pendente não pode fazer reservas.");
                return;
            }

            Revista revista = SelecionarRevistaDisponivel();
            if (revista == null) return;

            if (repoReserva.RevistaTemReservaAtiva(revista))
            {
                Console.WriteLine("Esta revista já está reservada por outro usuário.");
                return;
            }

            Reserva nova = new Reserva(amigo, revista);
            repoReserva.Inserir(nova);
            Console.WriteLine("Reserva criada com sucesso!");
        }

        private void CancelarReserva()
        {
            Console.Clear();
            Console.WriteLine("--- Cancelar Reserva ---");

            List<Reserva> ativas = repoReserva.SelecionarAtivas();
            if (ativas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva ativa.");
                return;
            }

            for (int i = 0; i < ativas.Count; i++)
                Console.WriteLine($"{i} - {ativas[i]}");

            Console.Write("Digite o número da reserva para cancelar: ");
            if (!int.TryParse(Console.ReadLine(), out int indice) || indice < 0 || indice >= ativas.Count)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            repoReserva.Cancelar(ativas[indice]);
            Console.WriteLine("Reserva cancelada com sucesso.");
        }

        private void VisualizarReservas()
        {
            Console.Clear();
            Console.WriteLine("--- Reservas Ativas ---");

            List<Reserva> reservas = repoReserva.SelecionarAtivas();

            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva ativa.");
                return;
            }

            foreach (var reserva in reservas)
                Console.WriteLine(reserva);
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

