using AutoMapper;
using Indt.Proposta.Domain.Entities;

namespace Indt.Proposta.Application.Propostas.ChangeStatus;

public class ChangeStatusProfile : Profile
{
    public ChangeStatusProfile()
    {
        CreateMap<PropostaEntity, ChangeStatusResult>();
        CreateMap<BeneficiarioEntity, ChangeStatusBeneficiarioResult>();
        CreateMap<CoberturaEntity, ChangeStatusCoberturaResult>();
    }
}