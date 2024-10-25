namespace ProjetoFiap.Models
{
    public class Aluno
    {
        public int id { get; set; }
        public required string nome { get; set; }
        public required string usuario { get; set; }
        public required string senha { get; set; }
        public int ativo { get; set; }
    }
}
