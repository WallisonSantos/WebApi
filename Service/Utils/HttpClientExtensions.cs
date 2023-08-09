using System.Net.Http.Headers;
using System.Text.Json;

namespace Service.Utils;
public static class HttpClientExtensions
{
    private static MediaTypeHeaderValue contentType = new("application/json");
    public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
    {
        if(!response.IsSuccessStatusCode) throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions{PropertyNameCaseInsensitive = true}) ?? throw new InvalidOperationException(nameof(response));
    }
}