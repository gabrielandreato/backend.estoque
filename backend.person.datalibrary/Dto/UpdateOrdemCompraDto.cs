namespace backend.person.datalibrary.Dto;

public class UpdateOrdemCompraDto
{
    public int IdProduto { get; set; }
    
    public int Quantidade  { get; set; }
    
    public int IdOrdemCompraStatus { get; set; }

    public decimal Valor { get; set; }

    public DateTime DtAprovacao { get; set; }

    public string? Observacao { get; set; }
}