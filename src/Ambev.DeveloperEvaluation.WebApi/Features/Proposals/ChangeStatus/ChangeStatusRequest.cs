using Indt.Proposta.Domain.Enums;

namespace Indt.Proposta.WebApi.Features.Proposals.ChangeStatus;

public class ChangeStatusRequest
{
    public required string Numero { get;set; }
    public int Status { get;set; }
}