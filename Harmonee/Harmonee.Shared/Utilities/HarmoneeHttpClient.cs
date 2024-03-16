using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Harmonee.Shared.Utilities;

public class HarmoneeHttpClient
{
    private readonly HttpClient _client;

    public HarmoneeHttpClient(HttpClient client)
    {
        _client = client;
    }

    public async ValueTask<T?> GetAsync<T>(string url, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(url, cancellationToken);
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async ValueTask<TResponse?> PostAsync<TPayload, TResponse>(string url, TPayload payload, CancellationToken token)
    {
        var response = await _client.PostAsJsonAsync<TPayload>(url, payload, token);
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async ValueTask<bool> PutAsync<TPayload>(string url, TPayload payload, CancellationToken token)
    {
        var response = await _client.PutAsJsonAsync<TPayload>(url, payload, token);
        return await response.Content.ReadFromJsonAsync<bool>();
    }

    public async ValueTask<bool> DeleteAsync(string url, CancellationToken token)
    {
        var response = await _client.DeleteAsync(url, token);
        return response.StatusCode == System.Net.HttpStatusCode.NoContent ? true : false;
    }
}
