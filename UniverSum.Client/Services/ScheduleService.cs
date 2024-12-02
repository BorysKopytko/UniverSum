using UniverSum.API.Models.Schedule;


namespace UniverSum.Client.Services;

internal class ScheduleService
{
    private string ApiUrlBase = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7023/" : "https://localhost:7023/";

    private readonly RequestService _requestService;

    public ScheduleService()
    {
        _requestService = new RequestService();
    }

    public async Task<IndividualLesson> GetLesson(int id)
    {
        var uri = $"{ApiUrlBase}api/Schedule/schedule/{id}";

        IndividualLesson lesson = await _requestService.GetAsync<IndividualLesson>(uri).ConfigureAwait(false);

        return lesson ?? null;
    }

    public async Task<IEnumerable<IndividualLesson>> GetLessonsForTodayAsync()
    {
        var uri = $"{ApiUrlBase}api/Schedule/scheduletoday";

        IEnumerable<IndividualLesson> lessons = await _requestService.GetAsync<IEnumerable<IndividualLesson>>(uri).ConfigureAwait(false);

        return lessons?.ToArray() ?? Enumerable.Empty<IndividualLesson>();
    }

    public async Task<IEnumerable<IndividualLesson>> GetLessonsForTomorrowAsync()
    {
        var uri = $"{ApiUrlBase}api/Schedule/scheduletomorrow";

        IEnumerable<IndividualLesson> lessons = await _requestService.GetAsync<IEnumerable<IndividualLesson>>(uri).ConfigureAwait(false);

        return lessons?.ToArray() ?? Enumerable.Empty<IndividualLesson>();
    }

    public async Task<IEnumerable<IndividualLesson>> GetLessonsForThisWeekAsync()
    {
        var uri = $"{ApiUrlBase}api/Schedule/schedulethisweek";

        IEnumerable<IndividualLesson> lessons = await _requestService.GetAsync<IEnumerable<IndividualLesson>>(uri).ConfigureAwait(false);

        return lessons?.ToArray() ?? Enumerable.Empty<IndividualLesson>();
    }

    public async Task<IEnumerable<IndividualLesson>> GetLessonsForNextWeekAsync()
    {
        var uri = $"{ApiUrlBase}api/Schedule/schedulenextweek";

        IEnumerable<IndividualLesson> lessons = await _requestService.GetAsync<IEnumerable<IndividualLesson>>(uri).ConfigureAwait(false);

        return lessons?.ToArray() ?? Enumerable.Empty<IndividualLesson>();
    }

    public async Task<bool> PutLessonAsync(IndividualLesson individualLesson)
    {
        var uri = $"{ApiUrlBase}api/Schedule/schedulenextweek";

        await _requestService.PutAsync<IndividualLesson>(uri, individualLesson).ConfigureAwait(false);

        return true;
    }


    //public async Task RegisterAsync(RegisterModel registerModel)
    //{
    //    var registerUrl = $"{ApiUrlBase}register";

    //    var _httpClient = new HttpClient();
    //    var json = JsonSerializer.Serialize(registerModel, new JsonSerializerOptions
    //    {
    //        PropertyNameCaseInsensitive = true
    //    });
    //    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
    //    var response = await _httpClient.PostAsync(registerUrl, stringContent);
    //    if (response.IsSuccessStatusCode)
    //    {
    //        var responseContent = await response.Content.ReadAsStringAsync();
    //    }
    //    else
    //    {
    //    }
    //}
}
