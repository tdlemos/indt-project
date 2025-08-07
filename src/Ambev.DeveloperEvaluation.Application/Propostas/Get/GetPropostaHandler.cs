using AutoMapper;
using FluentValidation;
using Indt.Proposta.Domain.Repositories;
using MediatR;

namespace Indt.Proposta.Application.Propostas.Get;

public class GetPropostaHandler : IRequestHandler<GetPropostaCommand, GetPropostaResult>
{
    private readonly IPropostaRepository _propostaRepository;
    private readonly IMapper _mapper;

    public GetPropostaHandler(
        IPropostaRepository propostaRepository,
        IMapper mapper)
    {
        _propostaRepository = propostaRepository;
        _mapper = mapper;
    }

    public async Task<GetPropostaResult> Handle(GetPropostaCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var propostas = await _propostaRepository.GetByNumeroAsync(request.Numero, cancellationToken);

        return _mapper.Map<GetPropostaResult>(propostas);
    }
}
