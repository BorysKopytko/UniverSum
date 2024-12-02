using UniverSum.API.Models.Courses;
using UniverSum.API.Models.Schedule;

namespace UniverSum.Client.Services;

internal class CourseService
{
    private string ApiUrlBase = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7023/" : "https://localhost:7023/";

    private readonly RequestService _requestService;

    public CourseService()
    {
        _requestService = new RequestService();
    }

    public async Task<Course> GetCourse(int id)
    {
        var uri = $"{ApiUrlBase}api/Courses/course/{id}";

        Course course = await _requestService.GetAsync<Course>(uri).ConfigureAwait(false);

        return course ?? null;
    }

    public async Task<IEnumerable<Course>> GetCoursesByCategory(string category)
    {
        var uri = $"{ApiUrlBase}api/Courses/coursescategory/{category}";

        IEnumerable<Course> courses = await _requestService.GetAsync<IEnumerable<Course>>(uri).ConfigureAwait(false);

        return courses?.ToArray() ?? Enumerable.Empty<Course>();
    }
}
