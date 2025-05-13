namespace backend.person.datalibrary.Dto;

public class CreatePedidoComItensDto
{
    
    public int Id { get; set; }

    public int IdPedidoStatus { get; set; }

    public string Observacao { get; set; }

    public int IdCliente { get; set; }

    public string FormaDePagamento { get; set; }

    public decimal Desconto  { get; set; }

    public decimal Taxas  { get; set; }

    public decimal PrecoBruto { get; set; }

    public List<CreatePedidoItensDto> ListaPedidoItens { get; set; }
    
}