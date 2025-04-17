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
    public string Descricao { get; set; }

    public int IdCliente { get; set; }

    public int IdCategoria { get; set; }

    public int IdMaterial { get; set; }

    public int IdMarca { get; set; }

    public decimal PrecoBruto { get; set; }

    public string FormaDePagamento { get; set; }

    public decimal Desconto { get; set; }

    public decimal Taxas { get; set; }

    public decimal PrecoFinal { get; set; }
}