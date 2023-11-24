using System.Net.Http.Json;

namespace harmonee.Client.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }

        public async ValueTask<T?> GetAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            return await _client.GetFromJsonAsync<T>(url, cancellationToken);
        }

        public async ValueTask<T?> PostAsync<T>(string url, T data, CancellationToken cancellationToken = default)
        {
            return await PostAsync<T, T>(url, data, cancellationToken);
        }

        public async ValueTask<TOut?> PostAsync<TIn, TOut>(string url, TIn data, CancellationToken cancellationToken = default)
        {
            var response = await _client.PostAsJsonAsync(url, data, cancellationToken);
            return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<TOut>();
        }

        public async ValueTask<TOut?> PutAsync<TIn, TOut>(string url, TIn data, CancellationToken cancellationToken = default)
        {
            var response = await _client.PutAsJsonAsync(url, data, cancellationToken);
            return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<TOut>();
        }

        public async ValueTask<bool> DeleteAsync(string url, CancellationToken cancellationToken = default)
        {
            var response = await _client.DeleteAsync(url, cancellationToken);
            return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<bool>();
        }
    }

    public interface IApiClient
    {
        public ValueTask<T?> GetAsync<T>(string url, CancellationToken cancellationToken = default);
        public ValueTask<T?> PostAsync<T>(string url, T data, CancellationToken cancellationToken = default);
        public ValueTask<TOut?> PostAsync<TIn, TOut>(string url, TIn data, CancellationToken cancellationToken = default);
        public ValueTask<TOut?> PutAsync<TIn, TOut>(string url, TIn data, CancellationToken cancellationToken = default);
        public ValueTask<bool> DeleteAsync(string url, CancellationToken cancellationToken = default);
    }
}
