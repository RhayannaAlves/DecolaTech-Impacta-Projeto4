using System.ComponentModel.DataAnnotations;

namespace StatusTarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string? TarefaTitulo { get; set; }
        public string? Descricao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DataFim { get; set; }  

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DataPrevistaFim { get; set; }

        public string? Status { get; set; }
    }
}
