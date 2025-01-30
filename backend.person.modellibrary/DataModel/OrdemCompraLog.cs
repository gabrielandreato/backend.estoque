using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.person.modellibrary.DataModel;

public class OrdemCompraLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int IdOrdemCompra { get; set; }
    public int IdOrdemCompraStatus { get; set; }
    public DateTime DtLog { get; set; }
}