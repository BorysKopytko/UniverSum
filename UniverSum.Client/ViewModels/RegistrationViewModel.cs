using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniverSum.Client.Identity;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace UniverSum.Client.ViewModels
{
    public partial class RegistrationViewModel : ObservableObject
    {
        public static string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7023/" : "https://localhost:7023/";
        private HttpClient _httpClient;

        [ObservableProperty]
        public string _email;

        [ObservableProperty]
        public string _password;

        [ObservableProperty]
        public string _lastName;

        [ObservableProperty]
        public string _firstName;

        [ObservableProperty]
        public string _middleName;

        [ObservableProperty]
        public List<string> _faculties;

        [ObservableProperty]
        public string _faculty;

        [ObservableProperty]
        public List<string> _educationLevels;

        [ObservableProperty]
        public string _educationLevel;

        [ObservableProperty]
        public List<string> _specialities;

        [ObservableProperty]
        public string _speciality;

        [ObservableProperty]
        public List<string> _specialityCourses;

        [ObservableProperty]
        public string _specialityCourse;

        [ObservableProperty]
        public List<string> _streams;

        [ObservableProperty]
        public string _stream;

        [ObservableProperty]
        public List<string> _groups;

        [ObservableProperty]
        public string _group;

        public RegistrationViewModel()
        {
            _httpClient = GetHttpClient();
        }

        private HttpClient GetHttpClient() => new(GetHttpClientHandler());

        private HttpClientHandler GetHttpClientHandler()
        {

            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true
            };
            return httpClientHandler;
        }

        [RelayCommand]
        private async Task Register()
        {
            var registerUrl = $"{BaseUrl}register";

            var registerModel = new RegisterModel
            {
                Email = Email,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName
            };

            var json = JsonSerializer.Serialize(registerModel, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(registerUrl, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
            }
            else
            {
            }
        }

        private async Task GetFaculties()
        {
            var registerUrl = $"{BaseUrl}api/faculties";


            var response = await _httpClient.GetAsync(registerUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
                Faculties = responseContent.ToList();
            }
        }
    }
}
