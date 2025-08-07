using Indt.Proposta.Domain.Entities;
using Indt.Proposta.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Indt.Proposta.ORM.Repositories;

public class PropostaRepository : IPropostaRepository
{
    private readonly DefaultContext _context;

    public PropostaRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<PropostaEntity> CreateAsync(Domain.Entities.PropostaEntity user, CancellationToken cancellationToken = default)
    {
        await _context.Propostas.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<PropostaEntity?> GetByNumeroAsync(string numero, CancellationToken cancellationToken = default)
    {
        return await _context.Propostas
            .Include(x => x.Beneficiarios)
            .Include(x => x.Coberturas)
            .FirstOrDefaultAsync(o => o.Numero == numero, cancellationToken);
    }

    public async Task<IEnumerable<PropostaEntity>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Propostas
            .Include(x => x.Beneficiarios)
            .Include(x => x.Coberturas)
            .ToListAsync(cancellationToken);
    }

    public async Task<PropostaEntity> UpdateAsync(PropostaEntity user, CancellationToken cancellationToken = default)
    {
        _context.Propostas.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }
}