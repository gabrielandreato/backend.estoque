using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.person.modellibrary.DataModel;

public class Email
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int id { get; set; }

    public int idCliente { get; set; }
    
    public string EmailCliente  { get; set; }
}