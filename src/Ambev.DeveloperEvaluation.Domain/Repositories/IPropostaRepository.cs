using Indt.Proposta.Domain.Entities;

namespace Indt.Proposta.Domain.Repositories;

public interface IPropostaRepository
{
    Task<Entities.PropostaEntity> CreateAsync(Entities.PropostaEntity user, CancellationToken cancellationToken = default);
    Task<PropostaEntity?> GetByNumeroAsync(string numero, CancellationToken cancellationToken = default);
    Task<Entities.PropostaEntity> UpdateAsync(Entities.PropostaEntity user, CancellationToken cancellationToken = default);
    Task<IEnumerable<PropostaEntity>> ListAsync(CancellationToken cancellationToken = default);
}