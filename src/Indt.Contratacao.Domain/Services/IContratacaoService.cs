using Indt.Contratacao.Domain.Models;

namespace Indt.Contratacao.Domain.Services;
public interface IContratacaoService
{
    Task<ContratacaoResult?> ContratarPropostaAsync(string numero);
}