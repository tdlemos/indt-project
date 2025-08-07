using Indt.Proposta.Domain.Enums;

namespace Indt.Proposta.WebApi.Features.Proposals.List;

public class ListPropostaRequest
{
    public OperacaoTipo TipoOperacao { get; set; }
}