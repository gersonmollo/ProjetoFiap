using ProjetoFiap.DataBase;
using ProjetoFiap.Interfaces;
using ProjetoFiap.Models;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoFiap.Services
{
    public class AlunoService : IAluno
    {

        public string Cadastrar(Aluno aluno)
        {
            IEnumerable<Aluno> data = this.PegarPorUsuario(aluno);

            if (!VerificarSenha(aluno.senha))
            {
                return "A senha precisa conter ao menos 1 letra maiúscula, 1 minúscula, 1 caractere especial e 1 digito!";
            }
            else if (data.Count() > 0)
            {
                return "Usuário ja existente!";
            }
            else 
            {
                byte[] newSenha = Encoding.UTF8.GetBytes(aluno.senha);
                aluno.senha = Convert.ToBase64String(newSenha);

                DBConection.ExecutarQuery<Aluno>($"INSERT INTO aluno (nome, usuario, senha, ativo) VALUES ('{aluno.nome}', '{aluno.usuario}', '{aluno.senha}', 1)");

                return "";
            }
        }
        public void Inativar(int id)
        {
            DBConection.ExecutarQuery<Aluno>($"UPDATE aluno SET ativo = 0 WHERE Id = { id }");
        }
        public string Editar(Aluno aluno)
        {
            IEnumerable<Aluno> data = this.PegarPorUsuario(aluno);

            if (!VerificarSenha(aluno.senha))
            {
                return "A senha precisa conter ao menos 1 letra maiúscula, 1 minúscula, 1 caractere especial e 1 digito!";
            }
            else if (data.Count() > 0)
            {
                return "Usuário ja existente!";
            }
            else
            {
                byte[] newSenha = Encoding.UTF8.GetBytes(aluno.senha);
                aluno.senha = Convert.ToBase64String(newSenha);

                DBConection.ExecutarQuery<Aluno>($"UPDATE aluno SET nome = '{aluno.nome}', usuario = '{aluno.usuario}', senha = '{aluno.senha}' WHERE id = {aluno.id}");

                return "";
            }            
        }
        public IEnumerable<Aluno> PegarPorId(int id)
        {
            IEnumerable<Aluno> aluno = DBConection.ExecutarQuery<Aluno>($"SELECT * FROM aluno WHERE id = {id}");

            foreach (var item in aluno)
            {
                byte[] data = Convert.FromBase64String(item.senha);
                item.senha = System.Text.Encoding.UTF8.GetString(data);
            }

            return aluno;
        }

        public IEnumerable<Aluno> PegarPorUsuario(Aluno aluno)
        {
            return DBConection.ExecutarQuery<Aluno>($"SELECT * FROM aluno WHERE usuario = '{aluno.usuario}' AND id <> {aluno.id}");
        }
        public IEnumerable<Aluno> Listar()
        {
            return DBConection.ExecutarQuery<Aluno>($"SELECT * FROM aluno");
        }
        public IEnumerable<Aluno> ListarAtivos()
        {
            return DBConection.ExecutarQuery<Aluno>($"SELECT * FROM aluno WHERE ativo = 1");
        }


        public bool VerificarSenha(string senha)
        {
            if (senha.Length < 8)
            {
                return false;
            }

            if (!Regex.IsMatch(senha, @"[A-Z]"))
            {
                return false;
            }
                
            if (!Regex.IsMatch(senha, @"[a-z]"))
            {
                return false;
            }
                
            if (!Regex.IsMatch(senha, @"[0-9]"))
            {
                return false;
            }
                
            if (!Regex.IsMatch(senha, @"[\W_]"))
            {
                return false;
            }
                
            return true;
        }
    }
}
