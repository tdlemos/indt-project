using Indt.Proposta.Domain.Enums;
using MediatR;
using Validation;

namespace Indt.Proposta.Application.Propostas.ChangeStatus;

public class ChangeStatusCommand : IRequest<ChangeStatusResult?>
{
    public required string Numero { get; set; }
    public ProposalStatus Status { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new ChangeStatusCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}