using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace backend.person.modellibrary.DataModel;

public class
    Pedido

{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int IdPedidoStatus { get; set; }
    public string Observacao   { get; set; }
    public int IdCliente { get; set; }
    public decimal? PrecoBruto { get; set; }
    public string FormaDePagamento { get; set; }
    public decimal? Desconto { get; set; }

    public decimal? Taxas { get; set; }

    
}