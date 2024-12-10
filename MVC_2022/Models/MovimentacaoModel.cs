namespace MVC_2024.Models
{
    public class MovimentacaoModel
    {
        public int Id { get; set; }

        public int estoqueId { get; set; }

        public string tipoMovimentacao { get; set; } //define se é entrada ou saida.

        public int quantidade { get; set; }

        public DateTime DataMovimentacao { get; set; }

        public virtual EstoqueModel Estoque { get; set; }


    }
}
