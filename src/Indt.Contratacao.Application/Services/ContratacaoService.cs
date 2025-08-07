using Indt.Contratacao.Application.Refit;
using Indt.Contratacao.Domain.Enums;
using Indt.Contratacao.Domain.Models;
using Indt.Contratacao.Domain.Services;
using Refit;

namespace Indt.Contratacao.Application.Services;

public class ContratacaoService : IContratacaoService
{
    private readonly IPropostaApi _propostaApi;

    public ContratacaoService(IPropostaApi propostaApi)
    {
        _propostaApi = propostaApi;
    }

    public async Task<ContratacaoResult?> ContratarPropostaAsync(string numero)
    {
        try
        {
            var proposta = await _propostaApi.GetPropostaByNumberAsync(numero);

            if (proposta is null)
                return null;

            if (proposta.Status != ProposalStatus.Approved)
                return null;

            return new()
            {
                Numero = numero,
                DataContratacao = DateTime.Now,
            };
        }
        catch (ApiException ex)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Proposta número {numero} não encontrada.");
            }
            else
            {
                Console.WriteLine($"API error: {ex.StatusCode} - {ex.Message}");
            }
        }

        return null;
    }
}
