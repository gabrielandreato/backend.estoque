namespace backend.person.modellibrary.Request;

public class GetEnderecoRequest
{
    public string? Ids { get; set; } = null;

    public int? IdCliente { get; set; } = null;

    public int? IdPais { get; set; } = null;

    public int? IdEstado { get; set; } = null;

    public string? Cidade { get; set; } = null;

    public string? Bairro { get; set; } = null;

    public string? Cep { get; set; } = null;

    public bool? EnderecoPrincipal { get; set; } = null;
}