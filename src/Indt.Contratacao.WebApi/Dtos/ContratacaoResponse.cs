namespace Indt.Contratacao.WebApi.Dtos;
public class ContratacaoResponse
{
    public string Numero { get; set; }
    public DateTime DataContratacao { get; set; }
}

public class ContratacaoRequest
{
    public string Numero { get; set; }
}