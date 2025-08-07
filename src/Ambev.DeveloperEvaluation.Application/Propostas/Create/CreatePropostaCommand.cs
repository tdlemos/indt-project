using Indt.Proposta.Domain.Enums;
using MediatR;
using Validation;

namespace Indt.Proposta.Application.Propostas.Create;

public class CreatePropostaCommand : IRequest<CreatePropostaResult>
{
    public string Numero { get; set; }
    public DateTime DataProposta { get; set; }
    public OperacaoTipo TipoOperacao { get; set; }
    public string AgenteTipo { get; set; }
    public string AgenteNome { get; set; }
    public string AgenteCNPJ { get; set; }
    public string Susep { get; set; }
    public string ProponenteNome { get; set; }
    public string ProponenteCPF { get; set; }
    public string ProponenteTipo { get; set; }
    public string ProponenteEndereco { get; set; }
    public string ProponenteBairro { get; set; }
    public string ProponenteCidade { get; set; }
    public string ProponenteUF { get; set; }
    public string ProponenteCEP { get; set; }
    public string ProponenteTelefone { get; set; }
    public string ProponenteEmail { get; set; }
    public DateTime ProponenteDataNascimento { get; set; }
    public string BemSeguradoTipoImovel { get; set; }
    public string BemSeguradoUtilizacaoImovel { get; set; }
    public bool BemSeguradoAtividadeComercial { get; set; }
    public string BemSeguradoAtividadeEndereco { get; set; }
    public string BemSeguradoAtividadeBairro { get; set; }
    public string BemSeguradoAtividadeCidade { get; set; }
    public string BemSeguradoAtividadeUF { get; set; }
    public string BemSeguradoAtividadeCEP { get; set; }
    public ProposalStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public virtual IEnumerable<CreateBeneficiarioCommand> Beneficiarios { get; set; }
    public virtual IEnumerable<CreateCoberturaCommand> Coberturas { get; set; }
    public ValidationResultDetail Validate()
    {
        var validator = new CreateProposalValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}