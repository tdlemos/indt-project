using FluentValidation;

namespace Indt.Proposta.Application.Propostas.Get;

public class GetUserValidator : AbstractValidator<GetPropostaCommand>
{
    public GetUserValidator()
    {
    }
}