namespace backend.person.datalibrary.Dto;

public class CreatePedidoComItensDto
{
    public string Observacao { get; set; }

    public List<CreatePedidoItensDto> ListaPedidoItens { get; set; }
    
}