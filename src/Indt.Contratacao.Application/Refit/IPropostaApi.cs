using Indt.Contratacao.Application.Models;
using Refit;

namespace Indt.Contratacao.Application.Refit;
public interface IPropostaApi
{
    [Get("/proposta/get/{numero}")]
    Task<PropostaModel> GetPropostaByNumberAsync(string numero);
}
