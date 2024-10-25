using ProjetoFiap.Services;

namespace ProjetoFiap.Models
{
    public class AlunoTurma
    {
        public int id { get; set; }
        public int aluno_id { get; set; }
        public int turma_id { get; set; }
        public IEnumerable<Aluno>? aluno { get; set; }
        public IEnumerable<Turma>? turma { get; set; }
        public int ativo { get; set; }
        public IEnumerable<Aluno> listaAlunosAtivos { get; set; }
        public IEnumerable<Turma> listaTurmasAtivas { get; set; }
    }
}
