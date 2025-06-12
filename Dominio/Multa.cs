namespace Academia_Programador_ClubeDaLeitura.Dominio
{
    public class Multa
    {
        public Emprestimo Emprestimo { get; set; }
        public double Valor { get; private set; }
        public string Status { get; private set; } // Pendente / Quitada

        public Multa(Emprestimo emprestimo)
        {
            Emprestimo = emprestimo;
            Valor = CalcularValor();
            Status = "Pendente";
        }

        private double CalcularValor()
        {
            var diasAtraso = (DateTime.Now - Emprestimo.DataDevolucao).Days;
            return diasAtraso > 0 ? diasAtraso * 2.0 : 0;
        }

        public void Quitar()
        {
            Status = "Quitada";
        }

        public bool EstaPendente()
        {
            return Status == "Pendente";
        }

        public override string ToString()
        {
            return $"{Emprestimo.Amigo.Nome} - R$ {Valor:F2} - {Status}";
        }
    }
}
