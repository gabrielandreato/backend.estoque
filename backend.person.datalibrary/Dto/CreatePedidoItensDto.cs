using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.person.datalibrary.Dto;

public class CreatePedidoItensDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    
    public int IdPedido{ get; set; }

    public int IdProduto { get; set; }

    public int Quantidade { get; set; }
}