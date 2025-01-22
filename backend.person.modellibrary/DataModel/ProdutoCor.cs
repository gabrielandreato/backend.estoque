using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.person.modellibrary.DataModel;

public class ProdutoCor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int IdProduto { get; set; }
    
    public int IdCor { get; set; }
}