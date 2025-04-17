using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.person.modellibrary.DataModel;

public class Cliente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }

    [MinLength(10)]
    public string Nome { get; set; }

    public DateTime DataNascimento { get; set; }

    public string CPF { get; set; }
    
}