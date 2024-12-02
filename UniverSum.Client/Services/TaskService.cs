using UniverSum.API.Models.Schedule;
using UniverSum.API.Models.Tasks;


namespace UniverSum.Client.Services;

internal class TaskService
{
    private string ApiUrlBase = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7023/" : "https://localhost:7023/";

    private readonly RequestService _requestService;

    public TaskService()
    {
        _requestService = new RequestService();
    }

    public async Task<CustomTask> GetTaskAsync(int id)
    {
        var uri = $"{ApiUrlBase}api/Tasks/task/{id}";

        CustomTask task = await _requestService.GetAsync<CustomTask>(uri).ConfigureAwait(false);

        return task ?? null;
    }

    public async Task<IEnumerable<CustomTask>> GetTasksAsync()
    {
        var uri = $"{ApiUrlBase}api/Tasks/tasks";

        IEnumerable<CustomTask> tasks = await _requestService.GetAsync<IEnumerable<CustomTask>>(uri).ConfigureAwait(false);

        return tasks?.ToArray() ?? Enumerable.Empty<CustomTask>();
    }
}
