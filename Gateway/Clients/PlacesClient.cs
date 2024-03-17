using Microsoft.Extensions.Logging;

namespace Gateway.Clients
{
    public interface IPlacesClient
    {
        Task<string> GetCoordinates(string name, string language, string country);
    }

    internal sealed class PlacesClient : IPlacesClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<PlacesClient> _logger;

        public PlacesClient(IHttpClientFactory clientFactory, ILogger<PlacesClient> logger)
        {
            _client = clientFactory.CreateClient(nameof(PlacesClient));
            _logger = logger;
        }

        public async Task<string> GetCoordinates(string name, string language, string? country)
        {
            if (_client.BaseAddress is null)
                return string.Empty;

            string requestUri = country != string.Empty ?
                _client.BaseAddress.ToString() + $"{language}/" + "places/" + "geoname" + $"?name={name}&country={country}"
                : _client.BaseAddress.ToString() + $"{language}/" + "places/" + "geoname" + $"?name={name}";

            HttpResponseMessage response = await _client.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}