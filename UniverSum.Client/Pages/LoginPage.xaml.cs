using System.Text;
using System.Text.Json;
using UniverSum.Client.Identity;

namespace UniverSum.Client.Pages;

public partial class LoginPage : ContentPage
{
    public static string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7023/" : "https://localhost:7023/";
    private HttpClient _httpClient;

    public LoginPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        

        

        base.OnAppearing();
        _httpClient = GetHttpClient();
        if (!string.IsNullOrWhiteSpace(await SecureStorage.Default.GetAsync("RefreshToken")))
            Refresh();
    }

    private HttpClient GetHttpClient() => new(GetHttpClientHandler());

    private HttpClientHandler GetHttpClientHandler()
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // EXCEPTION : Javax.Net.Ssl.SSLHandshakeException: 'java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.'
        // SOLUTION :
        var httpClientHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (_, _, _, _) => true
        };
        return httpClientHandler;
    }

    private async void Refresh()
    {
        var refreshUrl = $"{BaseUrl}refresh";

        var refreshModel = new RefreshModel
        {
            RefreshToken = await SecureStorage.Default.GetAsync("RefreshToken")
        };

        var json = JsonSerializer.Serialize(refreshModel, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(refreshUrl, stringContent);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            var responseModel = JsonSerializer.Deserialize<ResponseModel>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            await SecureStorage.Default.SetAsync("AccessToken", responseModel.AccessToken);
            await SecureStorage.Default.SetAsync("ExpiresIn", responseModel.ExpiresIn.ToString());
            await SecureStorage.Default.SetAsync("RefreshToken", responseModel.RefreshToken);

            Application.Current.MainPage = new AppShell();

            await Shell.Current.GoToAsync("//" + nameof(SchedulesPage));
        }
        else
        {
            await DisplayAlert("Повідомлення", $"Не вдалося відновити попередній вхід - {response.StatusCode}. Спробуйте ввійти знову.", "Закрити");
        }
    }
}