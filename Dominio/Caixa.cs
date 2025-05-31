namespace Academia_Programador_ClubeDaLeitura.Dominio
{
    public class Caixa
    {
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasEmprestimo { get; set; }

        public Caixa(string etiqueta, string cor, int diasEmprestimo = 7)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }

        public string Validar()
        {
            if (string.IsNullOrWhiteSpace(Etiqueta) || Etiqueta.Length > 50)
                return "Etiqueta deve ter no máximo 50 caracteres e não pode ser vazia.";

            if (string.IsNullOrWhiteSpace(Cor))
                return "A cor da caixa é obrigatória.";

            if (DiasEmprestimo <= 0)
                return "Dias de empréstimo deve ser um valor positivo.";

            return "VÁLIDO";
        }

        public override string ToString()
        {
            return $"{Etiqueta} (Cor: {Cor}, Dias de Empréstimo: {DiasEmprestimo})";
        }
    }
}

