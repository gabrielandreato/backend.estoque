using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.person.modellibrary.DataModel;

public class PedidoLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }

    public int IdPedido { get; set; }

    public int IdStatus { get; set; }
    [SwaggerSchema(ReadOnly = true)]
    public DateTime DtLogPedido { get; set; }
    
}