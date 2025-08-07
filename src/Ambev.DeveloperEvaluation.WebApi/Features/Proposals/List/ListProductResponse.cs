using Indt.Proposta.Domain.Enums;

namespace Indt.Proposta.WebApi.Features.Proposals.List;

public class ListPropostaResponse
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

    public virtual IEnumerable<ListBeneficiarioResponse> Beneficiarios { get; set; }
    public virtual IEnumerable<ListCoberturaResponse> Coberturas { get; set; }
}

public class ListCoberturaResponse
{
    public string Nome { get; set; }
    public decimal LimiteMaximoIndenizacao { get; set; }
    public decimal ParticipacaoFranquia { get; set; }
    public decimal PremioCobertura { get; set; }
}

public class ListBeneficiarioResponse
{
    public BeneficiatioTipo Tipo { get; set; }
    public string Nome { get; set; }
    public string CpfCnpj { get; set; }
}