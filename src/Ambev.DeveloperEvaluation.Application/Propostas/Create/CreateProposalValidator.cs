using FluentValidation;
using Indt.Proposta.Domain.Enums;

namespace Indt.Proposta.Application.Propostas.Create;

public class CreateProposalValidator : AbstractValidator<CreatePropostaCommand>
{
    public CreateProposalValidator()
    {
        RuleFor(user => user.Status).NotEqual(ProposalStatus.Nenhum);
    }
}