using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.person.modellibrary.DataModel;

public class EstoqueMovimento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   
    public int Id { get; set; }
    public int IdProduto { get; set; }
    public int Quantidade  { get; set; }
    public int Valor { get; set; }
    public int IdEstoqueEvento { get; set; }
    public DateTime DtInserido { get; set; }
}