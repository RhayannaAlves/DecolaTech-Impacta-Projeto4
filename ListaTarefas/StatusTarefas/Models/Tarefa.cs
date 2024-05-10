namespace StatusTarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string? TarefaTitulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime DataFim { get; set; } = DateTime.Now.AddDays(1); //Serve para garantir que a data de início seja anterior a data fim.
        public string? Status { get; set; }
    }
}
