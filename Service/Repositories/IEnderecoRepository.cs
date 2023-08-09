using Service.Models;

namespace Service.Repositories;

public interface IEnderecoRepository
{
    Task<EnderecoModel> FindByCep(string cep);
}