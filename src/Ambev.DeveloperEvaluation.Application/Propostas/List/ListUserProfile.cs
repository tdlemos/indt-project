using AutoMapper;
using Indt.Proposta.Domain.Entities;

namespace Indt.Proposta.Application.Propostas.List;

public class ListUserProfile : Profile
{
    public ListUserProfile()
    {
        CreateMap<PropostaEntity, ListPropostaResult>();
        CreateMap<BeneficiarioEntity, ListBeneficiarioResult>();
        CreateMap<CoberturaEntity, ListCoberturaResult>();
    }
}
