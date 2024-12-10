namespace MVC_2024.Models
{
    public class EstoqueModel
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public int? Quantidade { get; set; }

        public int? EstoqueMinimo { get; set; }

        public int? EstoqueMaximo { get; set; }

        public decimal? UnidadeMedida { get; set; }

        
        public bool VerificarEstoqueMinimo() => Quantidade <= EstoqueMinimo; //Expressão lambda que me diz se a "Quantidade" é menor ou igual à "EstoqueMinimo". 

    }
}
