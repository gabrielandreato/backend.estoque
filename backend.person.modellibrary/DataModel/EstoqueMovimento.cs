namespace backend.person.modellibrary.DataModel;

public class EstoqueMovimento
{
    public int Id { get; set; }
    public int IdProduto { get; set; }
    public int Quantidade  { get; set; }
    public int Valor { get; set; }
    public int IdEstoqueMovimento { get; set; }
}