using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public abstract class ApiClientBase
{
    private static readonly HttpClient _client = new HttpClient();
    protected string Api;

    protected ApiClientBase(string apiKey)
    {
        Api = apiKey;
    }

    protected async Task<T> HttpGetAsync<T>(string url)
    {
        var response = await _client.GetAsync(url);
        string responseBody = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            string Message = $"GET \"{url}\" returned {response.StatusCode}:\n{responseBody}";
            Exception e = new Exception(Message);
            throw e;
        }
        return JsonSerializer.Deserialize<T>(responseBody);
    }
}
