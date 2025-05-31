namespace Academia_Programador_ClubeDaLeitura.Dominio
{
    public class Revista
    {
        public string Titulo { get; set; }
        public int NumeroEdicao { get; set; }
        public int AnoPublicacao { get; set; }
        public string Status { get; private set; }
        public Caixa Caixa { get; set; }

        public Revista(string titulo, int numeroEdicao, int anoPublicacao, Caixa caixa)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            AnoPublicacao = anoPublicacao;
            Caixa = caixa;
            Status = "Disponível";
        }

        public string Validar()
        {
            if (string.IsNullOrWhiteSpace(Titulo) || Titulo.Length < 2 || Titulo.Length > 100)
                return "Título deve ter entre 2 e 100 caracteres.";

            if (NumeroEdicao <= 0)
                return "Número da edição deve ser maior que zero.";

            if (AnoPublicacao < 1900 || AnoPublicacao > DateTime.Now.Year)
                return "Ano de publicação inválido.";

            if (Caixa == null)
                return "Caixa obrigatória.";

            return "VÁLIDO";
        }

        public void Emprestar()
        {
            Status = "Emprestada";
        }

        public void Devolver()
        {
            Status = "Disponível";
        }

        public void Reservar()
        {
            Status = "Reservada";
        }

        public override string ToString()
        {
            return $"{Titulo} - Edição {NumeroEdicao} ({AnoPublicacao}) - Status: {Status} - Caixa: {Caixa?.Etiqueta}";
        }
    }
}

