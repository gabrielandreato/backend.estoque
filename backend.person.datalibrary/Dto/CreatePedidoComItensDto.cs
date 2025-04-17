namespace backend.person.datalibrary.Dto;

public class CreatePedidoComItensDto
{
    public int IdCategoria { get; set; }

    public int IdMaterial { get; set; }

    public int IdMarca { get; set; }

    public string FormaDePagamento { get; set; }
    public List<CreatePedidoItensDto> ListaPedidoItens { get; set; }
    
}