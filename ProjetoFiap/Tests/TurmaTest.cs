using ProjetoFiap.Models;
using ProjetoFiap.Services;
using Xunit;

namespace ProjetoFiap.Tests
{
    public class TurmaTest
    {
        private readonly TurmaService _turmaService;
        public TurmaTest()
        {
            _turmaService = new TurmaService();
        }

        [Fact]
        public void CadastrarTurmaComSucesso()
        {
            Turma turma = new Turma()
            {
                turma = "Teste Turma",
                curso_id = 1,
                ano = 2000
            };

            bool salvo = this._turmaService.Cadastrar(turma);

            Assert.True(salvo);
        }

        [Fact]
        public void CadastrarTurmaComNomeIgual()
        {
            Turma turma = new Turma()
            {
                id = 0,
                turma = "Gerson Mollo",
                curso_id = 1,
                ano = 2000,
                ativo = 1
            };

            bool salvo = this._turmaService.Cadastrar(turma);

            Assert.False(salvo);
        }

        [Fact]
        public void EditarTurmaComNomeNovo()
        {
            Turma turma = new Turma()
            {
                id = 1,
                turma = "Gerson Mollo 2",
                curso_id = 2,
                ano = 2005
            };

            bool salvo = this._turmaService.Editar(turma);

            Assert.True(salvo);
        }

        [Fact]
        public void EditarTurmaComNomeExistente()
        {
            Turma turma = new Turma()
            {
                id = 2,
                turma = "Daiane Camargo",
                curso_id = 2,
                ano = 2005
            };

            bool salvo = this._turmaService.Editar(turma);

            Assert.False(salvo);
        }

        [Fact]
        public void InativarTurma()
        {
            this._turmaService.Inativar(1);

            Assert.True(true);
        }
    }
}
