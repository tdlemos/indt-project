using AutoMapper;
using FluentValidation;
using Indt.Proposta.Domain.Entities;
using Indt.Proposta.Domain.Repositories;
using MediatR;

namespace Indt.Proposta.Application.Propostas.List;

public class ListPropostaHandler : IRequestHandler<ListPropostaCommand, IEnumerable<ListPropostaResult>>
{
    private readonly IPropostaRepository _propostaRepository;
    private readonly IMapper _mapper;

    public ListPropostaHandler(
        IPropostaRepository propostaRepository,
        IMapper mapper)
    {
        _propostaRepository = propostaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ListPropostaResult>> Handle(ListPropostaCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var propostas = await _propostaRepository.ListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<PropostaEntity>, IEnumerable<ListPropostaResult>>(propostas);
    }
}
