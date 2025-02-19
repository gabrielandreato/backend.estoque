using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.person.modellibrary.DataModel;

public class PedidoLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int IdPedido { get; set; }

    public int IdStatus { get; set; }
    
    public DateTime DtLogPedido { get; set; }
    
}