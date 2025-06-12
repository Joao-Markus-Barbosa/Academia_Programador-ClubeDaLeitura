namespace Academia_Programador_ClubeDaLeitura.Dominio
{
    public class Emprestimo
    {
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string Situacao { get; private set; } // Aberto, Concluído, Atrasado
        public bool FoiDevolvido { get; private set; }

        public Emprestimo(Amigo amigo, Revista revista)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = CalcularDataDevolucao();
            Situacao = "Aberto";
            FoiDevolvido = false;
        }

        public string Validar()
        {
            if (Amigo == null)
                return "Amigo obrigatório.";

            if (Revista == null)
                return "Revista obrigatória.";

            if (Revista.Status != "Disponível")
                return "Revista não está disponível para empréstimo.";

            return "VÁLIDO";
        }

        public DateTime CalcularDataDevolucao()
        {
            return DataEmprestimo.AddDays(Revista.Caixa.DiasEmprestimo);
        }

        public bool EstaAtrasado()
        {
            return !FoiDevolvido && DateTime.Now > DataDevolucao;
        }

        public void RegistrarDevolucao()
        {
            FoiDevolvido = true;
            Revista.Devolver();
            Situacao = DateTime.Now > DataDevolucao ? "Atrasado" : "Concluído";
        }

        public override string ToString()
        {
            string status = Situacao == "Atrasado" ? "🔴 Atrasado" : Situacao;
            return $"{Amigo.Nome} - {Revista.Titulo} - Devolver até {DataDevolucao:dd/MM/yyyy} - {status}";
        }
    }
}


