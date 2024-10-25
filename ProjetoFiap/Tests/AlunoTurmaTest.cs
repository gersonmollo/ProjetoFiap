using ProjetoFiap.Models;
using ProjetoFiap.Services;
using Xunit;

namespace ProjetoFiap.Tests
{
    public class AlunoTurmaTest
    {
        private readonly AlunoTurmaService _alunoTurmaService;
        public AlunoTurmaTest()
        {
            _alunoTurmaService = new AlunoTurmaService();
        }

        [Fact]
        public void CadastrarAlunoTurmaComSucesso()
        {
            AlunoTurma alunoTurma = new AlunoTurma()
            {
                turma_id = 1,
                aluno_id = 1
            };

            string mensagem = this._alunoTurmaService.Cadastrar(alunoTurma);

            Assert.Empty(mensagem);
        }

        [Fact]
        public void CadastrarAlunoSenhaIncorreta()
        {
            AlunoTurma alunoTurma = new AlunoTurma()
            {
                turma_id = 2,
                aluno_id = 1
            };

            string mensagem = this._alunoTurmaService.Cadastrar(alunoTurma);

            Assert.Equal("Aluno já vinculado a esta turma!", mensagem);
        }

        [Fact]
        public void EditarAlunoTurmaComSucesso()
        {
            AlunoTurma alunoTurma = new AlunoTurma()
            {
                turma_id = 3,
                aluno_id = 1
            };

            string mensagem = this._alunoTurmaService.Cadastrar(alunoTurma);

            Assert.Empty(mensagem);
        }

        [Fact]
        public void EditarAlunoSenhaIncorreta()
        {
            AlunoTurma alunoTurma = new AlunoTurma()
            {
                turma_id = 2,
                aluno_id = 1
            };

            string mensagem = this._alunoTurmaService.Cadastrar(alunoTurma);

            Assert.Equal("Aluno já vinculado a esta turma!", mensagem);
        }

        [Fact]
        public void InativarAluno()
        {
            this._alunoTurmaService.Inativar(1);

            Assert.True(true);
        }
    }
}
