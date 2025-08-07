using AutoMapper;
using Indt.Proposta.Domain.Entities;

namespace Indt.Proposta.Application.Propostas.Get;

public class GetUserProfile : Profile
{
    public GetUserProfile()
    {
        CreateMap<PropostaEntity, GetPropostaResult>();
        CreateMap<BeneficiarioEntity, GetBeneficiarioResult>();
        CreateMap<CoberturaEntity, GetCoberturaResult>();
    }
}
