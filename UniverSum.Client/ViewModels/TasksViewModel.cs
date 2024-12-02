using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniverSum.API.Models.Tasks;
using UniverSum.Client.Pages;
using UniverSum.Client.Services;

namespace UniverSum.Client.ViewModels
{
    public partial class TasksViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<CustomTask> _items;

        private readonly TaskService taskService;

        public TasksViewModel()
        {
            taskService = new TaskService();
            var task = Task.Run(LoadItems);
            task.Wait();
        }

        private async Task LoadItems()
        {
            IEnumerable<CustomTask> customTasks = await taskService.GetTasksAsync();
            Items = customTasks.ToList();
        }

        [RelayCommand]
        private async Task Details(int id)
        {
            await Shell.Current.GoToAsync(nameof(TaskDetailPage));
        }
    }
}
