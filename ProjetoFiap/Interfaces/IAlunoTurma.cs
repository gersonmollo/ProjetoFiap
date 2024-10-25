using ProjetoFiap.Models;

namespace ProjetoFiap.Interfaces
{
    public interface IAlunoTurma
    {
        public AlunoTurma PegarPorId(int id);
        public string Cadastrar(AlunoTurma turma);
        public string Editar(AlunoTurma turma);
        public void Inativar(int id);
        public IEnumerable<AlunoTurma> PegarPorIds(AlunoTurma alunoTurma);
        public List<AlunoTurma> Listar(); 
    }
}
