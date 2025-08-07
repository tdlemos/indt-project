using Indt.Proposta.Domain.Enums;

namespace Indt.Proposta.Application.Propostas.ChangeStatus;

public class ChangeStatusResult
{
    public string Numero { get; set; } = string.Empty;

    public DateTime DataProposta { get; set; }

    public OperacaoTipo TipoOperacao { get; set; } = OperacaoTipo.NovaContratacao;
    public string AgenteTipo { get; set; } = string.Empty;
    public string AgenteNome { get; set; } = string.Empty;
    public string AgenteCNPJ { get; set; } = string.Empty;
    public string Susep { get; set; } = string.Empty;

    public string ProponenteNome { get; set; } = string.Empty;
    public string ProponenteCPF { get; set; } = string.Empty;
    public string ProponenteTipo { get; set; } = string.Empty;
    public string ProponenteEndereco { get; set; } = string.Empty;
    public string ProponenteBairro { get; set; } = string.Empty;
    public string ProponenteCidade { get; set; } = string.Empty;
    public string ProponenteUF { get; set; } = string.Empty;
    public string ProponenteCEP { get; set; } = string.Empty;
    public string ProponenteTelefone { get; set; } = string.Empty;
    public string ProponenteEmail { get; set; } = string.Empty;
    public DateTime ProponenteDataNascimento { get; set; }

    public string? BemSeguradoTipoImovel { get; set; }
    public string? BemSeguradoUtilizacaoImovel { get; set; }
    public bool BemSeguradoAtividadeComercial { get; set; }
    public string? BemSeguradoAtividadeEndereco { get; set; }
    public string? BemSeguradoAtividadeBairro { get; set; }
    public string? BemSeguradoAtividadeCidade { get; set; }
    public string? BemSeguradoAtividadeUF { get; set; }
    public string? BemSeguradoAtividadeCEP { get; set; }

    public ProposalStatus Status { get; set; } = ProposalStatus.Analise;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual List<ChangeStatusBeneficiarioResult> Beneficiarios { get; set; } = [];
    public virtual List<ChangeStatusCoberturaResult> Coberturas { get; set; } = [];
}

public class ChangeStatusBeneficiarioResult
{
    public BeneficiatioTipo Tipo { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
}

public class ChangeStatusCoberturaResult
{
    public string Nome { get; set; } = string.Empty;
    public decimal LimiteMaximoIndenizacao { get; set; }
    public decimal ParticipacaoFranquia { get; set; }
    public decimal PremioCobertura { get; set; }
}