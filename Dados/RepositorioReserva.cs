using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Dados
{
    public class RepositorioReserva
    {
        private List<Reserva> listaReservas = new List<Reserva>();

        public void Inserir(Reserva reserva)
        {
            listaReservas.Add(reserva);
        }

        public void Cancelar(Reserva reserva)
        {
            reserva.Cancelar();
        }

        public List<Reserva> SelecionarAtivas()
        {
            return listaReservas.Where(r => r.EstaAtiva()).ToList();
        }

        public List<Reserva> SelecionarPorAmigo(Amigo amigo)
        {
            return listaReservas.Where(r => r.Amigo == amigo).ToList();
        }

        public bool RevistaTemReservaAtiva(Revista revista)
        {
            return listaReservas.Any(r => r.Revista == revista && r.EstaAtiva());
        }

        public Reserva ObterReservaAtiva(Revista revista, Amigo amigo)
        {
            return listaReservas.FirstOrDefault(r => r.Revista == revista && r.Amigo == amigo && r.EstaAtiva());
        }
    }
}

