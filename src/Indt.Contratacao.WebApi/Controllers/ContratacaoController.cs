using Indt.Contratacao.Domain.Services;
using Indt.Contratacao.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Indt.Contratacao.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ContratacaoController : ControllerBase
{

    private readonly IContratacaoService _contratacaoService;
    public ContratacaoController(IContratacaoService contratacaoService)
    {
        _contratacaoService = contratacaoService;
    }


    [HttpPost]
    [ProducesResponseType(typeof(ContratacaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Contratacao([FromBody] ContratacaoRequest request)
    {
        var response = await _contratacaoService.ContratarPropostaAsync(request.Numero);

        if(response is null)
            return NotFound();

        return Ok(response);
    }
}
