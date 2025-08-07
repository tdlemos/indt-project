using Indt.Proposta.Domain.Enums;
using MediatR;

namespace Indt.Proposta.Application.Propostas.List;

public class ListPropostaCommand : IRequest<IEnumerable<ListPropostaResult>>
{
    public OperacaoTipo TipoOperacao { get; set; }
}
