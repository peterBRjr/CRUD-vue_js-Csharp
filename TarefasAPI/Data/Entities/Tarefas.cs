using System.ComponentModel.DataAnnotations;

namespace tareaAPI.Data.Entities
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public int situacao { get; set; }
    }
}