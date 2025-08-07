using AutoMapper;
using Indt.Proposta.Domain.Entities;

namespace Indt.Proposta.Application.Propostas.Create;

public class CreatePropostaProfile : Profile
{
    public CreatePropostaProfile()
    {
        CreateMap<CreatePropostaCommand, PropostaEntity>();

        CreateMap<CreateBeneficiarioCommand, BeneficiarioEntity>();

        CreateMap<CreateCoberturaCommand, CoberturaEntity>();

        CreateMap<PropostaEntity, CreatePropostaResult>();

        CreateMap<BeneficiarioEntity, CreateBeneficiarioResult>();

        CreateMap<CoberturaEntity, CreateCoberturaResult>();
    }
}