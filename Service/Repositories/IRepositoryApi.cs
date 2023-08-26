using Service.Models;

namespace Service.Repositories;

public interface IRepositoryApi
{
    Task<EnderecoModel> FindByCep(string cep);
    Task<EconomiaModel> FindByCode(string code);
}