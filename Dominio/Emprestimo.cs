namespace Academia_Programador_ClubeDaLeitura.Dominio
{
    public class Emprestimo
    {
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string Situacao { get; private set; }

        public Emprestimo(Amigo amigo, Revista revista)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = CalcularDataDevolucao();
            Situacao = "Aberto";
        }

        public string Validar()
        {
            if (Amigo == null)
                return "Amigo obrigatório.";

            if (Revista == null || Revista.Status != "Disponível")
                return "Revista inválida ou indisponível.";

            return "VÁLIDO";
        }

        public DateTime CalcularDataDevolucao()
        {
            return DataEmprestimo.AddDays(Revista.Caixa.DiasEmprestimo);
        }

        public void RegistrarDevolucao()
        {
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

