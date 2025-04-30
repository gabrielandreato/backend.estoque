using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace backend.person.modellibrary.DataModel;

public class Endereco
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public int IdPais { get; set; }

    public int IdEstado { get; set; }
    public string  Cidade { get; set; }
    
    [MinLength(8)]
    public string CEP { get; set; }
    public string Bairro { get; set; }
    public string Rua { get; set; }

    public string Numero { get; set; }
    public bool EnderecoPrincipal { get; set; }
    
}