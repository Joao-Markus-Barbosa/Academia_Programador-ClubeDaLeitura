namespace Academia_Programador_ClubeDaLeitura.Dominio
{
    public class Reserva
    {
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataReserva { get; set; }
        public string Status { get; private set; } // Ativa / Concluída

        public Reserva(Amigo amigo, Revista revista)
        {
            Amigo = amigo;
            Revista = revista;
            DataReserva = DateTime.Now;
            Status = "Ativa";
        }

        public void Concluir()
        {
            Status = "Concluída";
        }

        public void Cancelar()
        {
            Status = "Concluída";
        }

        public bool EstaAtiva()
        {
            return Status == "Ativa";
        }

        public override string ToString()
        {
            return $"{Amigo.Nome} reservou \"{Revista.Titulo}\" em {DataReserva:dd/MM/yyyy} - {Status}";
        }
    }
}

