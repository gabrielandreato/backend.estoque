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
    public decimal? Preco { get; set; }

    public int IdMaterial { get; set; }

    public int IdCategoria { get; set; }

    public int IdMarca { get; set; }
}