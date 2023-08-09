
using Service.Models;
using Service.Utils;

namespace Service.Repositories;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly HttpClient _client;

    public EnderecoRepository(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<EnderecoModel> FindByCep(string cep)
    {
        var response = await _client.GetAsync($"https://brasilapi.com.br/api/cep/v1/{cep}");
        return await response.ReadContentAs<EnderecoModel>();
    }
}