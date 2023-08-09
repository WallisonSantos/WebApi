using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Repositories;

namespace Service.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    public IEnderecoRepository _enderecoRepository;
    public EnderecoController(IEnderecoRepository enderecoRepository)
    {
        _enderecoRepository = enderecoRepository ?? throw new ArgumentNullException(nameof(enderecoRepository));
    }

    [HttpGet("{cep}")]
    public async Task<ActionResult<EnderecoModel>> FindByCep(string cep)
    {
        var response = await _enderecoRepository.FindByCep(cep);
        if(cep == null) return NotFound();
        return Ok(response);
    }
}