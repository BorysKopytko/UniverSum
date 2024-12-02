
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace UniverSum.Client.Services;

public class RequestService
{
    private readonly Lazy<HttpClient> _httpClient =
        new(() =>
        {
            var httpClient = new HttpClient();
#if DEBUG
            var handler = GetPlatformMessageHandler();
            if (handler != null)
                httpClient = new HttpClient(handler);
            else
                httpClient = new HttpClient();
#else
            _client = new HttpClient();
#endif

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        },
            LazyThreadSafetyMode.ExecutionAndPublication);

    public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
    {
        HttpClient httpClient = GetOrCreateHttpClient(token);
        var accessToken = await SecureStorage.Default.GetAsync("AccessToken");

        if (!string.IsNullOrWhiteSpace(accessToken))
        {
            httpClient.SetBearerToken(accessToken);
        }
        HttpResponseMessage response = await httpClient.GetAsync(uri).ConfigureAwait(false);

        await RequestService.HandleResponse(response).ConfigureAwait(false);

        TResult result = await response.Content.ReadFromJsonAsync<TResult>();

        return result;
    }

    public async Task<bool> PutAsync<TResult>(string uri, TResult data, string token = "", string header = "")
    {
        HttpClient httpClient = GetOrCreateHttpClient(token);
        var accessToken = await SecureStorage.Default.GetAsync("AccessToken");

        if (!string.IsNullOrWhiteSpace(accessToken))
        {
            httpClient.SetBearerToken(accessToken);
        }
        if (!string.IsNullOrEmpty(header))
        {
            RequestService.AddHeaderParameter(httpClient, header);
        }

        var content = new StringContent(JsonSerializer.Serialize(data));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = await httpClient.PutAsync(uri, content).ConfigureAwait(false);

        bool result = true;
        try
        {
            await RequestService.HandleResponse(response).ConfigureAwait(false);
        }
        catch
        {
            result = false;
        }

        return result;
    }

    private HttpClient GetOrCreateHttpClient(string token = "")
    {
        var httpClient = _httpClient.Value;



        httpClient.DefaultRequestHeaders.Authorization =
            !string.IsNullOrEmpty(token)
                ? new AuthenticationHeaderValue("Bearer", token)
                : null;

        return httpClient;
    }

    private static void AddHeaderParameter(HttpClient httpClient, string parameter)
    {
        if (httpClient == null)
            return;

        if (string.IsNullOrEmpty(parameter))
            return;

        httpClient.DefaultRequestHeaders.Add(parameter, Guid.NewGuid().ToString());
    }

    private static async Task HandleResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.Unauthorized)
            {
                
            }

            
        }
    }

    public static HttpMessageHandler GetPlatformMessageHandler()
    {
#if ANDROID
        var handler = new Xamarin.Android.Net.AndroidMessageHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
        {
            if (cert != null && cert.Issuer.Equals("CN=localhost"))
                return true;
            return errors == System.Net.Security.SslPolicyErrors.None;
        };
        return handler;
#elif WINDOWS
        return null;
#else
        throw new PlatformNotSupportedException("Only Windows and Android supported.");
#endif
    }
}
