using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniverSum.API.Models.Courses;

using UniverSum.Client.Pages;
using UniverSum.Client.Services;

namespace UniverSum.Client.ViewModels
{
    public partial class CoursesViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<Course> _items;

        private readonly CourseService courseService;

        public CoursesViewModel()
        {
            courseService = new CourseService();
            var task = Task.Run(LoadItems);
            task.Wait();
        }

        private async Task LoadItems()
        {
            if (Shell.Current.CurrentItem.CurrentItem.Title == "Усі")
            {
                IEnumerable<Course> courses = await courseService.GetCoursesByCategory("all");
                Items = courses.ToList();
            }
            else if (Shell.Current.CurrentItem.CurrentItem.Title == "Обов'язкові")
            {
                IEnumerable<Course> courses = await courseService.GetCoursesByCategory("required");
                Items = courses.ToList();
            }
            else if (Shell.Current.CurrentItem.CurrentItem.Title == "Факультетські ДВВС")
            {
                IEnumerable<Course> courses = await courseService.GetCoursesByCategory("faculty");
                Items = courses.ToList();
            }
            else if (Shell.Current.CurrentItem.CurrentItem.Title == "Університетські ДВВС")
            {
                IEnumerable<Course> courses = await courseService.GetCoursesByCategory("university");
                Items = courses.ToList();
            }
        }

        [RelayCommand]
        private async Task Details(int id)
        {
            await Shell.Current.GoToAsync(nameof(CourseDetailPage));
        }
    }
}
