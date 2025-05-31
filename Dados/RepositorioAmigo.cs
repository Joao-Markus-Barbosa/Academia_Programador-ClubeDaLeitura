using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Dados
{
    public class RepositorioAmigo
    {
        private List<Amigo> listaAmigos = new List<Amigo>();

        public bool Inserir(Amigo novoAmigo)
        {
            if (listaAmigos.Any(a => a.Nome == novoAmigo.Nome && a.Telefone == novoAmigo.Telefone))
                return false;

            listaAmigos.Add(novoAmigo);
            return true;
        }

        public bool Editar(int indice, Amigo amigoAtualizado)
        {
            if (indice < 0 || indice >= listaAmigos.Count)
                return false;

            listaAmigos[indice] = amigoAtualizado;
            return true;
        }

        public bool Excluir(int indice)
        {
            if (indice < 0 || indice >= listaAmigos.Count)
                return false;

            listaAmigos.RemoveAt(indice);
            return true;
        }

        public List<Amigo> SelecionarTodos()
        {
            return listaAmigos;
        }

        public Amigo SelecionarPorIndice(int indice)
        {
            if (indice < 0 || indice >= listaAmigos.Count)
                return null;

            return listaAmigos[indice];
        }

        public int ObterIndice(Amigo amigo)
        {
            return listaAmigos.IndexOf(amigo);
        }

        public bool PossuiEmprestimosVinculados(Amigo amigo)
        {
            // Este método será conectado futuramente com o RepositorioEmprestimo
            return false;
        }
    }
}

