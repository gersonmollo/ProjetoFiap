using System.ComponentModel.DataAnnotations;

namespace ProjetoFiap.Models
{
    public class Turma
    {
        public int id { get; set; }
        public required int curso_id { get; set; }
        public required string turma { get; set; }
        public required int ano { get; set; }
        public int ativo { get; set; }
    }
}
