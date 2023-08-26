using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Repositories;

namespace Service.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    public IRepositoryApi _repository;

    public EnderecoController(IRepositoryApi repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet("{cep}")]
    public async Task<ActionResult<EnderecoModel>> FindByCep(string cep)
    {
        var response = await _repository.FindByCep(cep);
        if(cep == null) return NotFound();
        return Ok(response);
    }

    [HttpGet("aspx/{code}")]
    public async Task<ActionResult<EconomiaModel>> FindByCode(string code)
    {
        var response = await _repository.FindByCode(code);
        if(code == null) return NotFound();
        return Ok(response);
    }
}