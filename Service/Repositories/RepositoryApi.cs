
using Service.Models;
using Service.Utils;

namespace Service.Repositories;

public class RepositoryApi : IRepositoryApi
{
    private readonly HttpClient _client;

    public RepositoryApi(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<EnderecoModel> FindByCep(string cep)
    {
        var response = await _client.GetAsync($"https://brasilapi.com.br/api/cep/v1/{cep}");
        return await response.ReadContentAs<EnderecoModel>();
    }

    public async Task<EconomiaModel> FindByCode(string kind)
    {
        var response = await _client.GetAsync($"https://pokeapi.co/api/v2/ability/{kind}");
        return await response.ReadContentAs<EconomiaModel>();
    }
}