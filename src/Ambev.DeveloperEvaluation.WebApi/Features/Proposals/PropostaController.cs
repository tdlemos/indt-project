using AutoMapper;
using Indt.Proposta.Application.Propostas.ChangeStatus;
using Indt.Proposta.Application.Propostas.Create;
using Indt.Proposta.Application.Propostas.Get;
using Indt.Proposta.Application.Propostas.List;
using Indt.Proposta.WebApi.Common;
using Indt.Proposta.WebApi.Features.Proposals.ChangeStatus;
using Indt.Proposta.WebApi.Features.Proposals.Create;
using Indt.Proposta.WebApi.Features.Proposals.Get;
using Indt.Proposta.WebApi.Features.Proposals.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Indt.Proposta.WebApi.Features.Proposals;

[ApiController]
[Route("proposta")]
public class PropostaController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PropostaController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("get/{numero}")]
    [ProducesResponseType(typeof(GetPropostaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCart([FromRoute] string numero, CancellationToken cancellationToken)
    {
        var command = new GetPropostaCommand { Numero = numero };

        var result = await _mediator.Send(command, cancellationToken);

        if(result is null)
            return NotFound();

        var response = _mapper.Map<GetPropostaResponse>(result);

        return Ok(response);
    }

    [HttpGet("list")]
    [ProducesResponseType(typeof(IEnumerable<ListPropostaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListCart([FromQuery] ListPropostaRequest request, CancellationToken cancellationToken)
    {

        var command = _mapper.Map<ListPropostaCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        var response = _mapper.Map<IEnumerable<ListPropostaResponse>>(result);

        return Ok(response);
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(CreatePropostaResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProposta([FromBody] CreatePropostaRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreatePropostaCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(_mapper.Map<CreatePropostaResponse>(result));
    }

    [HttpPost("change-status")]
    [ProducesResponseType(typeof(ChangeStatusResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangeStatusProposta([FromBody] ChangeStatusRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<ChangeStatusCommand>(request);

        var result = await _mediator.Send(command, cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(_mapper.Map<ChangeStatusResponse>(result));
    }
}