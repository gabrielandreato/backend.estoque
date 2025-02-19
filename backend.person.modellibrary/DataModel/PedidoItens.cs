using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.person.modellibrary.DataModel;

public class PedidoItens
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int IdPedido { get; set; }
    
    public int IdProduto { get; set; }

    public int Quantidade { get; set; }
    
}