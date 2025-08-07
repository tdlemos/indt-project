using AutoMapper;
using Indt.Proposta.Application.Propostas.ChangeStatus;
using Indt.Proposta.Application.Propostas.Create;
using Indt.Proposta.Application.Propostas.Get;
using Indt.Proposta.Application.Propostas.List;
using Indt.Proposta.WebApi.Features.Proposals.ChangeStatus;
using Indt.Proposta.WebApi.Features.Proposals.Create;
using Indt.Proposta.WebApi.Features.Proposals.Get;
using Indt.Proposta.WebApi.Features.Proposals.List;

namespace Indt.Proposta.WebApi.Features.Proposals;

public class PropostaProfile : Profile
{
    public PropostaProfile()
    {
        // Criar Proposta
        CreateMap<CreatePropostaRequest, CreatePropostaCommand>();
        CreateMap<CreateBeneficiarioRequest, CreateBeneficiarioCommand>();
        CreateMap<CreateCoberturaRequest, CreateCoberturaCommand>();

        CreateMap<CreatePropostaResult, CreatePropostaResponse>();
        CreateMap<CreateBeneficiarioResult, CreateBeneficiarioResponse>();
        CreateMap<CreateCoberturaResult, CreateCoberturaResponse>();

        // Listar Propostas
        CreateMap<ListPropostaRequest, ListPropostaCommand>();

        CreateMap<ListPropostaResult, ListPropostaResponse>();
        CreateMap<ListBeneficiarioResult, ListBeneficiarioResponse>();
        CreateMap<ListCoberturaResult, ListCoberturaResponse>();

        // Alterar Status
        CreateMap<ChangeStatusRequest, ChangeStatusCommand>();

        CreateMap<ChangeStatusResult, ChangeStatusResponse>();
        CreateMap<ChangeStatusBeneficiarioResult, ChangeStatusBeneficiarioResponse>();
        CreateMap<ChangeStatusCoberturaResult, ChangeStatusCoberturaResponse>();

        // Get Propostas
        CreateMap<GetPropostaResult, GetPropostaResponse>();
        CreateMap<GetBeneficiarioResult, GetBeneficiarioResponse>();
        CreateMap<GetCoberturaResult, GetCoberturaResponse>();
    }
}