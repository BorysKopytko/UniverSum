using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UniverSum.Client.Identity;
using UniverSum.Client.Pages;

namespace UniverSum.Client.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        public static string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7023/" : "https://localhost:7023/";
        private HttpClient _httpClient;

        [ObservableProperty]
        public string _email;

        [ObservableProperty]
        public string _password;

        public LoginViewModel()
        {
            _httpClient = GetHttpClient();
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

        [RelayCommand]
        private async Task Login()
        {
            var loginUrl = $"{BaseUrl}login?useCookies=false";

            var loginModel = new LoginModel
            {
                Email = Email,
                Password = Password
            };

            var json = JsonSerializer.Serialize(loginModel, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(loginUrl, stringContent);
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

                await Shell.Current.GoToAsync("//"+nameof(SchedulesPage));
            }
            else
            {
            }
        }

        [RelayCommand]
        private async Task Register()
        {
            await Shell.Current.GoToAsync(nameof(RegistrationPage));
        }

    }
}
