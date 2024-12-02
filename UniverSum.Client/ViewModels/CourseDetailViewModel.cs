using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniverSum.API.Models.Courses;
using UniverSum.Client.Services;

namespace UniverSum.Client.ViewModels
{
    public partial class CourseDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        public Course _item;

        private readonly CourseService courseService;

        public CourseDetailViewModel()
        {
            courseService = new CourseService();
            var task = Task.Run(LoadItem);
            task.Wait();
        }

        private async void LoadItem()
        {
            var task = await courseService.GetCourse(0);
            Item = task;
        }

        [RelayCommand]
        private async Task LoadContent(int id)
        {

        }
    }
}
