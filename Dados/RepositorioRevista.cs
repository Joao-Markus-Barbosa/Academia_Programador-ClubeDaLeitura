using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Dados
{
    public class RepositorioRevista
    {
        private List<Revista> listaRevistas = new List<Revista>();

        public bool Inserir(Revista revista)
        {
            if (listaRevistas.Any(r => r.Titulo == revista.Titulo && r.NumeroEdicao == revista.NumeroEdicao))
                return false;

            listaRevistas.Add(revista);
            return true;
        }

        public bool Editar(int indice, Revista revistaAtualizada)
        {
            if (indice < 0 || indice >= listaRevistas.Count)
                return false;

            listaRevistas[indice] = revistaAtualizada;
            return true;
        }

        public bool Excluir(int indice)
        {
            if (indice < 0 || indice >= listaRevistas.Count)
                return false;

            listaRevistas.RemoveAt(indice);
            return true;
        }

        public List<Revista> SelecionarTodos()
        {
            return listaRevistas;
        }

        public Revista SelecionarPorIndice(int indice)
        {
            if (indice < 0 || indice >= listaRevistas.Count)
                return null;

            return listaRevistas[indice];
        }

        public List<Revista> SelecionarDisponiveis()
        {
            return listaRevistas.Where(r => r.Status == "Disponível").ToList();
        }
    }
}

