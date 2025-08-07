namespace Indt.Proposta.Application.Propostas.Create;

public class CreateCoberturaCommand
{
    public string Nome { get; set; }
    public decimal LimiteMaximoIndenizacao { get; set; }
    public decimal ParticipacaoFranquia { get; set; }
    public decimal PremioCobertura { get; set; }
}