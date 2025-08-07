using FluentValidation;
using Indt.Proposta.Domain.Enums;

namespace Indt.Proposta.Domain.Validation;

public class PropostaValidator : AbstractValidator<Entities.PropostaEntity>
{
    public PropostaValidator()
    {   
        RuleFor(prop => prop.ProponenteTelefone)
            .Matches(@"^\[1-9]\d{10,14}$")
            .WithMessage("Telefone do Proponente de conter de 11-15 digitos");
        
        RuleFor(prop => prop.Status)
            .NotEqual(ProposalStatus.Nenhum)
            .WithMessage("O Status da proposta não pode ser Nenhum");
    }
}
