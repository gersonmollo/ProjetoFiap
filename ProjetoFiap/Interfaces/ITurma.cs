using ProjetoFiap.Models;

namespace ProjetoFiap.Interfaces
{
    public interface ITurma
    {
        public IEnumerable<Turma> PegarPorId(int id);
        public bool Cadastrar(Turma turma);
        public bool Editar(Turma turma);
        public void Inativar(int id);
        public IEnumerable<Turma> PegarPorNome(string nome);
        public IEnumerable<Turma> Listar();
    }
}
