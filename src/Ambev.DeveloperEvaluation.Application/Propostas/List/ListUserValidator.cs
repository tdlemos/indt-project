using FluentValidation;

namespace Indt.Proposta.Application.Propostas.List;

public class ListUserValidator : AbstractValidator<ListPropostaCommand>
{
    public ListUserValidator()
    {
    }
}