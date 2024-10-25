using ProjetoFiap.Models;

namespace ProjetoFiap.Interfaces
{
    public interface IAluno
    {
        public IEnumerable<Aluno> PegarPorId(int id);
        public string Cadastrar(Aluno aluno);
        public string Editar(Aluno aluno);
        public void Inativar(int id);
        public IEnumerable<Aluno> Listar();
        public bool VerificarSenha(string senha);
    }
}
