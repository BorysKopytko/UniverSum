using CommunityToolkit.Mvvm.ComponentModel;
using UniverSum.API.Models.Tasks;
using UniverSum.Client.Services;

namespace UniverSum.Client.ViewModels
{
    public partial class TaskDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        public CustomTask _item;

        private readonly TaskService taskService;

        public TaskDetailViewModel()
        {
            taskService = new TaskService();
            var task = Task.Run(LoadItem);
            task.Wait();
        }

        private async void LoadItem()
        {
            var task = await taskService.GetTaskAsync(0);
            Item = task;
        }
    }
}
