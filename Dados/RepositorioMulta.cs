using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Dados
{
    public class RepositorioMulta
    {
        private List<Multa> listaMultas = new List<Multa>();

        public void Inserir(Multa multa)
        {
            listaMultas.Add(multa);
        }

        public List<Multa> SelecionarTodas()
        {
            return listaMultas;
        }

        public List<Multa> SelecionarPendentes()
        {
            return listaMultas.Where(m => m.Status == "Pendente").ToList();
        }

        public List<Multa> SelecionarPorAmigo(Amigo amigo)
        {
            return listaMultas.Where(m => m.Emprestimo.Amigo == amigo).ToList();
        }

        public bool AmigoTemMultaPendente(Amigo amigo)
        {
            return listaMultas.Any(m => m.Emprestimo.Amigo == amigo && m.Status == "Pendente");
        }
    }
}

