using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.person.modellibrary.DataModel;

public class 
    Pedido

{
   [Key]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int IdPedidoStatus { get; set; }
    
    public string Observacao { get; set; }
    
}