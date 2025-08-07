using Indt.Proposta.Domain.Common;
using Indt.Proposta.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indt.Proposta.Domain.Entities;

public class BeneficiarioEntity: BaseEntity
{
    [Required]
    public int PropostaId { get; set; }

    [ForeignKey(nameof(PropostaId))]
    public PropostaEntity? Proposta { get; set; }

    public BeneficiatioTipo Tipo { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
}
