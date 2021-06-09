using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class NeoWsClient : ApiClientBase,
    INasaClient<AsteroidRequest, Task<AsteroidLookUp[]>>
{
    private string _urlFeed;
    private string _urlLookUp;

    public NeoWsClient(string ApiKey) : base(ApiKey)
    {
        _urlFeed = "https://api.nasa.gov/neo/rest/v1/feed";
        _urlLookUp = "https://api.nasa.gov/neo/rest/v1/neo/";
    }
    
    public async Task<AsteroidLookUp[]> GetAsync(AsteroidRequest request)
    {
        string urlRequest = _urlFeed + $"?start_date={request.StartDate:yyyy-MM-dd}&end_date={request.EndDate:yyyy-MM-dd}&api_key={Api}";
        FeedResponse response = await HttpGetAsync<FeedResponse>(urlRequest);
        List<AsteroidInfo> asteroidInfos = new List<AsteroidInfo>();
        foreach (var aValue in response.near_earth_objects.Values)
        {
            foreach (var asteroidValue in aValue)
            {
                asteroidValue.distance = double.Parse(asteroidValue.close_approach_data[0].miss_distance.kilometers);
                asteroidInfos.Add(asteroidValue);
            }
        }
        var asteroids =
            (from asteroid in asteroidInfos
                orderby asteroid.distance
                select asteroid).ToArray();
        int count = asteroids.Count() < request.ResultCount ? asteroids.Count() : request.ResultCount;
        AsteroidLookUp[] ret = new AsteroidLookUp[count];
        for (int i = 0; i < count; i++)
        {
            string urlAst = _urlLookUp + $"{asteroids[i].id}?api_key={Api}";
            ret[i] = await HttpGetAsync<AsteroidLookUp>(urlAst);
        }
        return ret;
    }
}