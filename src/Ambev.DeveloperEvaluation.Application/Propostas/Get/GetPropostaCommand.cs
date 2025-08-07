using MediatR;

namespace Indt.Proposta.Application.Propostas.Get;

public class GetPropostaCommand : IRequest<GetPropostaResult>
{
    public required string Numero { get; set; }
}
