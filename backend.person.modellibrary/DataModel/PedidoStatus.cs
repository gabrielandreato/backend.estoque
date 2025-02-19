using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.person.modellibrary.DataModel;

public class PedidoStatus
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    
    public int Id { get; set; }
    public string Descricao { get; set; }
    
}