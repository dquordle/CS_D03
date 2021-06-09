using System.Threading.Tasks;

public class ApodClient : ApiClientBase,
    INasaClient<int, Task<MediaOfToday[]>>
{
    private string _url;

    public ApodClient(string ApiKey) : base(ApiKey)
    {
        _url = "https://api.nasa.gov/planetary/apod";
    }

    public async Task<MediaOfToday[]> GetAsync(int ResultCount)
    {
        string urlRequest = _url + $"?count={ResultCount}&api_key={Api}";
        MediaOfToday[] media = await HttpGetAsync<MediaOfToday[]>(urlRequest);
        return media;
    }
}
