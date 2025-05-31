using Academia_Programador_ClubeDaLeitura.Dominio;

namespace Academia_Programador_ClubeDaLeitura.Dados
{
    public class RepositorioEmprestimo
    {
        private List<Emprestimo> listaEmprestimos = new List<Emprestimo>();

        public void Inserir(Emprestimo emprestimo)
        {
            listaEmprestimos.Add(emprestimo);
        }

        public List<Emprestimo> SelecionarTodos()
        {
            return listaEmprestimos;
        }

        public List<Emprestimo> SelecionarAtivos()
        {
            return listaEmprestimos.Where(e => e.Situacao == "Aberto").ToList();
        }

        public List<Emprestimo> SelecionarConcluidos()
        {
            return listaEmprestimos.Where(e => e.Situacao != "Aberto").ToList();
        }

        public List<Emprestimo> ObterPorAmigo(Amigo amigo)
        {
            return listaEmprestimos.Where(e => e.Amigo == amigo).ToList();
        }

        public bool AmigoTemEmprestimoAberto(Amigo amigo)
        {
            return listaEmprestimos.Any(e => e.Amigo == amigo && e.Situacao == "Aberto");
        }
    }
}

