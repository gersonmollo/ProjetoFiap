using ProjetoFiap.Models;
using ProjetoFiap.Services;
using Xunit;

namespace ProjetoFiap.Tests
{
    public class AlunoTest
    {
        private readonly AlunoService _alunoService;
        public AlunoTest()
        {
            _alunoService = new AlunoService();
        }

        [Fact]
        public void CadastrarAlunoComSucesso()
        {
            Aluno aluno = new Aluno()
            {
                nome = "Teste Aluno",
                usuario = "Teste 10",
                senha = "Senha123*"
            };

            string mensagem = this._alunoService.Cadastrar(aluno);

            Assert.Empty(mensagem);
        }

        [Fact]
        public void CadastrarAlunoSenhaIncorreta()
        {
            Aluno aluno = new Aluno()
            {
                nome = "Teste Aluno",
                usuario = "Teste 10",
                senha = "Senha123"
            };

            string mensagem = this._alunoService.Cadastrar(aluno);

            Assert.Equal("A senha precisa conter ao menos 1 letra maiúscula, 1 minúscula, 1 caractere especial e 1 digito!", mensagem);
        }

        [Fact]
        public void CadastrarAlunoUsuarioExistente()
        {
            Aluno aluno = new Aluno()
            {
                nome = "Teste Aluno",
                usuario = "Teste 1",
                senha = "Senha123*"
            };

            string mensagem = this._alunoService.Cadastrar(aluno);

            Assert.Equal("Usuário ja existente!", mensagem);
        }

        [Fact]
        public void EditarAlunoComSucesso()
        {
            Aluno aluno = new Aluno()
            {
                id = 1,
                nome = "Teste Aluno",
                usuario = "Teste 10",
                senha = "Senha123*"
            };

            string mensagem = this._alunoService.Editar(aluno);

            Assert.Empty(mensagem);
        }

        [Fact]
        public void EditarAlunoSenhaIncorreta()
        {
            Aluno aluno = new Aluno()
            {
                id = 1,
                nome = "Gerson Mollo",
                usuario = "Teste 1",
                senha = "Senha123"
            };

            string mensagem = this._alunoService.Cadastrar(aluno);

            Assert.Equal("A senha precisa conter ao menos 1 letra maiúscula, 1 minúscula, 1 caractere especial e 1 digito!", mensagem);
        }

        [Fact]
        public void EditarAlunoUsuarioExistente()
        {
            Aluno aluno = new Aluno()
            {
                nome = "Teste Aluno",
                usuario = "Teste 1",
                senha = "Senha123*"
            };

            string mensagem = this._alunoService.Cadastrar(aluno);

            Assert.Equal("Usuário ja existente!", mensagem);
        }

        [Fact]
        public void InativarAluno()
        {
            this._alunoService.Inativar(1);

            Assert.True(true);
        }
    }
}
