using AutoMapper;
using FluentValidation;
using Indt.Proposta.Domain.Entities;
using Indt.Proposta.Domain.Repositories;
using MediatR;

namespace Indt.Proposta.Application.Propostas.Create;

public class CreatePropostaHandler : IRequestHandler<CreatePropostaCommand, CreatePropostaResult>
{
    private readonly IPropostaRepository _propostaRepository;
    private readonly IMapper _mapper;

    public CreatePropostaHandler(IPropostaRepository userRepository, IMapper mapper)
    {
        _propostaRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<CreatePropostaResult> Handle(CreatePropostaCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProposalValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var proposta = await _propostaRepository.GetByNumeroAsync(command.Numero, cancellationToken);
        
        if(proposta is not null)
            throw new InvalidOperationException($"Proposta {command.Numero} já existe");

        var propostaEntity = _mapper.Map<PropostaEntity>(command);

        propostaEntity.CreatedAt = DateTime.UtcNow;

        var createdUser = await _propostaRepository.CreateAsync(propostaEntity, cancellationToken);

        var result = _mapper.Map<CreatePropostaResult>(createdUser);

        return result;
    }
}