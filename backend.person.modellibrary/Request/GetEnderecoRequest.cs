namespace backend.person.modellibrary.Request;

public class GetEnderecoRequest
{
    public string? Ids  { get; set; }

    public int? idCliente { get; set; }

    public int? idPais { get; set; }

    public int? idEstado { get; set; }

    public string? Cidade { get; set; }

    public string? Bairro { get; set; }

    public string? Cep { get; set; }

    public bool EnderecoPrincipal { get; set; }
     
    
    //int[]? ids = null, int? idCliente = null,
   // int? idPais  = null,int? idEstado = null, string? Cidade = null, string? Bairro = null, string? Cep = null)
}