using Indt.Proposta.Domain.Enums;

namespace Indt.Proposta.Application.Propostas.Create;

public class CreateBeneficiarioCommand
{
    public BeneficiatioTipo Tipo { get; set; }
    public string Nome { get; set; }
    public string CpfCnpj { get; set; }
}