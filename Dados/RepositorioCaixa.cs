using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Dados
{
    public class RepositorioCaixa
    {
        private List<Caixa> listaCaixas = new List<Caixa>();

        public bool Inserir(Caixa novaCaixa)
        {
            if (listaCaixas.Any(c => c.Etiqueta == novaCaixa.Etiqueta))
                return false;

            listaCaixas.Add(novaCaixa);
            return true;
        }

        public bool Editar(int indice, Caixa caixaAtualizada)
        {
            if (indice < 0 || indice >= listaCaixas.Count)
                return false;

            listaCaixas[indice] = caixaAtualizada;
            return true;
        }

        public bool Excluir(int indice)
        {
            if (indice < 0 || indice >= listaCaixas.Count)
                return false;

            listaCaixas.RemoveAt(indice);
            return true;
        }

        public List<Caixa> SelecionarTodos()
        {
            return listaCaixas;
        }

        public Caixa SelecionarPorIndice(int indice)
        {
            if (indice < 0 || indice >= listaCaixas.Count)
                return null;

            return listaCaixas[indice];
        }

        public int ObterIndice(Caixa caixa)
        {
            return listaCaixas.IndexOf(caixa);
        }

        public bool PossuiRevistasVinculadas(Caixa caixa)
        {
            // Validação futura (quando tivermos RepositorioRevista)
            return false;
        }
    }
}
