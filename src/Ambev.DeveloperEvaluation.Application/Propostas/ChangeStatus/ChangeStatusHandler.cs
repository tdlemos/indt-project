using AutoMapper;
using FluentValidation;
using Indt.Proposta.Domain.Repositories;
using MediatR;

namespace Indt.Proposta.Application.Propostas.ChangeStatus;

public class ChangeStatusHandler : IRequestHandler<ChangeStatusCommand, ChangeStatusResult?>
{
    private readonly IPropostaRepository _propostaRepository;
    private readonly IMapper _mapper;

    public ChangeStatusHandler(IPropostaRepository propostaRepository, IMapper mapper)
    {
        _propostaRepository = propostaRepository;
        _mapper = mapper;
    }

    public async Task<ChangeStatusResult?> Handle(ChangeStatusCommand command, CancellationToken cancellationToken)
    {
        var validator = new ChangeStatusCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var proposta = await _propostaRepository.GetByNumeroAsync(command.Numero, cancellationToken);

        if(proposta is null)
            return null;

        proposta.UpdatedAt = DateTime.UtcNow;
        proposta.Status = command.Status;

        var updatedUser = await _propostaRepository.UpdateAsync(proposta, cancellationToken);

        var result = _mapper.Map<ChangeStatusResult>(updatedUser);
        return result;
    }
}