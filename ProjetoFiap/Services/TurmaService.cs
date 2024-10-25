using ProjetoFiap.DataBase;
using ProjetoFiap.Interfaces;
using ProjetoFiap.Models;
using System.Collections.Generic;

namespace ProjetoFiap.Services
{
    public class TurmaService : ITurma
    {
        public bool Cadastrar(Turma turma)
        {
            IEnumerable<Turma> data = this.PegarPorNome(turma.turma);

            if (data.Count() == 0)
            {
                DBConection.ExecutarQuery<Turma>($"INSERT INTO turma (curso_id, turma, ano, ativo) VALUES ('{turma.curso_id}', '{turma.turma}', '{turma.ano}', 1)");

                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void Inativar(int id)
        {
            DBConection.ExecutarQuery<Turma>($"UPDATE turma SET ativo = 0 WHERE Id = {id}");
        }
        public bool Editar(Turma turma)
        {
            IEnumerable<Turma> data = this.PegarPorNome(turma.turma);

            if (data.Count() == 0)
            {
                DBConection.ExecutarQuery<Turma>($"UPDATE turma SET curso_id = '{turma.curso_id}', turma = '{turma.turma}', ano = '{turma.ano}' WHERE id = {turma.id}");

                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<Turma> PegarPorId(int id)
        {
            return DBConection.ExecutarQuery<Turma>($"SELECT * FROM turma WHERE id = {id}");
        }
        public IEnumerable<Turma> PegarPorNome(string nome)
        {
            return DBConection.ExecutarQuery<Turma>($"SELECT * FROM turma WHERE turma = '{nome}'");
        }
        public IEnumerable<Turma> Listar()
        {
            return DBConection.ExecutarQuery<Turma>($"SELECT * FROM turma");
        }
        public IEnumerable<Turma> ListarAtivos()
        {
            return DBConection.ExecutarQuery<Turma>($"SELECT * FROM turma WHERE ativo = 1");
        }
    }
}
