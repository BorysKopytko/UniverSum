
using System.Text;
using System.Text.Json;
using UniverSum.Client.Identity;

namespace UniverSum.Client.Services;

internal class RegistrationService
{
    private string ApiUrlBase = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7023/" : "https://localhost:7023/";

    private readonly RequestService _requestService;

    public RegistrationService()
    {
        _requestService = new RequestService();
    }

    public async Task<IEnumerable<string>> GetFacultiesAsync()
    {
        var uri = $"{ApiUrlBase}api/Registration/faculties";

        IEnumerable<string> faculties = await _requestService.GetAsync<IEnumerable<string>>(uri).ConfigureAwait(false);

        return faculties?.ToArray() ?? Enumerable.Empty<string>();
    }

    public async Task<IEnumerable<int>> GetEducationLevelsAsync(string faculty)
    {
        var uri = $"{ApiUrlBase}api/Registration/educationlevels?faculty={faculty}";

        IEnumerable<int> faculties = await _requestService.GetAsync<IEnumerable<int>>(uri).ConfigureAwait(false);

        return faculties?.ToArray() ?? Enumerable.Empty<int>();
    }

    public async Task<IEnumerable<string>> GetSpecialitiesAsync(string faculty, string educationLevel)
    {
        var uri = $"{ApiUrlBase}api/Registration/specialities?faculty={faculty}&educationLevel={educationLevel}";

        IEnumerable<string> faculties = await _requestService.GetAsync<IEnumerable<string>>(uri).ConfigureAwait(false);

        return faculties?.ToArray() ?? Enumerable.Empty<string>();
    }

    public async Task<IEnumerable<string>> GetSpecialityCoursesAsync(string faculty, string educationLevel, string speciality)
    {
        var uri = $"{ApiUrlBase}api/Registration/specialitycourses?faculty={faculty}&educationLevel={educationLevel.ToString()}&speciality={speciality}";

        IEnumerable<string> faculties = await _requestService.GetAsync<IEnumerable<string>>(uri).ConfigureAwait(false);

        return faculties?.ToArray() ?? Enumerable.Empty<string>();
    }

    public async Task<IEnumerable<string>> GetStreamsAsync(string faculty, string educationLevel, string speciality, string specialityCourse)
    {
        var uri = $"{ApiUrlBase}api/Registration/streams?faculty={faculty}&educationLevel={educationLevel}&speciality={speciality}&specialityCourse={specialityCourse.ToString()}";

        IEnumerable<string> faculties = await _requestService.GetAsync<IEnumerable<string>>(uri).ConfigureAwait(false);

        return faculties?.ToArray() ?? Enumerable.Empty<string>();
    }

    public async Task<IEnumerable<string>> GetGroupsAsync(string faculty, string educationLevel, string speciality, string specialityCourse, string stream)
    {
        var uri = $"{ApiUrlBase}api/Registration/groups?faculty={faculty}&educationLevel={educationLevel}&speciality={speciality}&specialityCourse={specialityCourse.ToString()}&stream={stream.ToString()}";

        IEnumerable<string> faculties = await _requestService.GetAsync<IEnumerable<string>>(uri).ConfigureAwait(false);

        return faculties?.ToArray() ?? Enumerable.Empty<string>();
    }

    public async Task RegisterAsync(RegisterModel registerModel)
    {
        var registerUrl = $"{ApiUrlBase}register";

        var _httpClient = new HttpClient();
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
}
