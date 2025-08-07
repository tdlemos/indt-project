using Indt.Proposta.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indt.Proposta.Domain.Entities;

public class CoberturaEntity : BaseEntity
{
    [Required]
    public int PropostaId { get; set; }

    [ForeignKey(nameof(PropostaId))]
    public PropostaEntity? Proposta { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal LimiteMaximoIndenizacao { get; set; }
    public decimal ParticipacaoFranquia { get; set; }
    public decimal PremioCobertura { get; set; }
}