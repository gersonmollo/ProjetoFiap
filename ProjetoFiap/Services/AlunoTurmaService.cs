using ProjetoFiap.DataBase;
using ProjetoFiap.Interfaces;
using ProjetoFiap.Models;
using System.Text;

namespace ProjetoFiap.Services
{
    public class AlunoTurmaService : IAlunoTurma
    {
        private readonly AlunoService _alunoService;
        private readonly TurmaService _turmaService;

        public AlunoTurmaService()
        {
            _alunoService = new AlunoService();
            _turmaService = new TurmaService();
        }
        public string Cadastrar(AlunoTurma alunoTurma)
        {
            IEnumerable<AlunoTurma> data = this.PegarPorIds(alunoTurma);

            if (data.Count() > 0)
            {
                return "Aluno já vinculado a esta turma!";
            }
            else
            {
                DBConection.ExecutarQuery<AlunoTurma>($"INSERT INTO aluno_turma (aluno_id, turma_id, ativo) VALUES ({alunoTurma.aluno_id}, {alunoTurma.turma_id}, 1)");

                return "";
            }
        }
        public void Inativar(int id)
        {
            DBConection.ExecutarQuery<AlunoTurma>($"UPDATE aluno_turma SET ativo = 0 WHERE id = {id}");
        }
        public void InativarPorAluno(int alunoId)
        {
            DBConection.ExecutarQuery<AlunoTurma>($"UPDATE aluno_turma SET ativo = 0 WHERE aluno_id = {alunoId}");
        }
        public void InativarPorTurma(int turmaId)
        {
            DBConection.ExecutarQuery<AlunoTurma>($"UPDATE aluno_turma SET ativo = 0 WHERE turma_id = {turmaId}");
        }
        public string Editar(AlunoTurma alunoTurma)
        {
            IEnumerable<AlunoTurma> data = this.PegarPorIds(alunoTurma);

            if (data.Count() > 0)
            {
                return "Aluno já vinculado a esta turma!";
            }
            else
            {
                DBConection.ExecutarQuery<AlunoTurma>($"UPDATE aluno_turma SET aluno_id = {alunoTurma.aluno_id}, turma_id = {alunoTurma.turma_id} WHERE id = {alunoTurma.id}");

                return "";
            }

            
        }
        public AlunoTurma PegarPorId(int id)
        {
            IEnumerable<AlunoTurma> data = DBConection.ExecutarQuery<AlunoTurma>($"SELECT * FROM aluno_turma WHERE id = { id }");

            AlunoTurma alunoTurma = new AlunoTurma();

            foreach (var item in data)
            {
                alunoTurma.aluno_id = item.aluno_id;
                alunoTurma.turma_id = item.turma_id;
            }

            alunoTurma.aluno = this._alunoService.PegarPorId(alunoTurma.aluno_id);
            alunoTurma.turma = this._turmaService.PegarPorId(alunoTurma.turma_id);

            return alunoTurma;
        }

        public IEnumerable<AlunoTurma> PegarPorIds(AlunoTurma alunoTurma)
        {
            return DBConection.ExecutarQuery<AlunoTurma>($"SELECT * FROM aluno_turma WHERE aluno_id = {alunoTurma.aluno_id} AND turma_id = {alunoTurma.turma_id} AND id <> {alunoTurma.id} AND ativo = 1");
        }

        public List<AlunoTurma> Listar()
        {
            IEnumerable<AlunoTurma> data = DBConection.ExecutarQuery<AlunoTurma>($"SELECT * FROM aluno_turma");

            List<AlunoTurma> list = new List<AlunoTurma>();

            foreach (var item in data)
            {
                list.Add(new AlunoTurma()
                {
                    id = item.id,
                    aluno_id = item.aluno_id,
                    turma_id = item.turma_id,
                    ativo = item.ativo,
                    aluno = this._alunoService.PegarPorId(item.aluno_id),
                    turma = this._turmaService.PegarPorId(item.turma_id)
                });
            }

            return list;
        }
    }
}
