using FluentValidation;
using Indt.Proposta.Domain.Enums;

namespace Indt.Proposta.Application.Propostas.ChangeStatus;

public class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
{
    public ChangeStatusCommandValidator()
    {
        RuleFor(user => user.Status).NotEqual(ProposalStatus.Nenhum);
    }
}
