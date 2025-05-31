namespace Academia_Programador_ClubeDaLeitura.Dominio
{
    public class Amigo
    {
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public string Telefone { get; set; }

        public Amigo(string nome, string responsavel, string telefone)
        {
            Nome = nome;
            Responsavel = responsavel;
            Telefone = telefone;
        }

        public string Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 3 || Nome.Length > 100)
                return "Nome deve ter entre 3 e 100 caracteres.";

            if (string.IsNullOrWhiteSpace(Responsavel) || Responsavel.Length < 3 || Responsavel.Length > 100)
                return "Responsável deve ter entre 3 e 100 caracteres.";

            if (!ValidarTelefone(Telefone))
                return "Telefone inválido. Use o formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.";

            return "VÁLIDO";
        }

        private bool ValidarTelefone(string telefone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(telefone,
                @"^\(\d{2}\) \d{4,5}-\d{4}$");
        }

        public override string ToString()
        {
            return $"{Nome} (Responsável: {Responsavel}, Telefone: {Telefone})";
        }
    }
}

