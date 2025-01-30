namespace backend.person.modellibrary.DataModel;

public class PedidoItens
{
    public int Id { get; set; }
    
    public int IdPedido { get; set; }
    
    public int IdProduto { get; set; }

    public int Quantidade { get; set; }
    
}