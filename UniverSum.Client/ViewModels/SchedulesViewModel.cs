using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniverSum.API.Models.Schedule;
using UniverSum.Client.Pages;
using UniverSum.Client.Services;

namespace UniverSum.Client.ViewModels
{
    public partial class SchedulesViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<IndividualLesson> _items;

        private readonly ScheduleService scheduleService;

        public SchedulesViewModel()
        {
            scheduleService = new ScheduleService();
            var task = Task.Run(LoadItems);
            task.Wait();
        }

        private async Task LoadItems()
        {
            if (Shell.Current.CurrentItem.CurrentItem.Title == "Сьогодні")
            {
                IEnumerable<IndividualLesson> individualLessons = await scheduleService.GetLessonsForTodayAsync();
                Items = individualLessons.ToList();
            }
            else if (Shell.Current.CurrentItem.CurrentItem.Title == "Завтра")
            {
                IEnumerable<IndividualLesson> individualLessons = await scheduleService.GetLessonsForTomorrowAsync();
                Items = individualLessons.ToList();
            }
            else if (Shell.Current.CurrentItem.CurrentItem.Title == "Цей тиждень")
            {
                IEnumerable<IndividualLesson> individualLessons = await scheduleService.GetLessonsForThisWeekAsync();
                Items = individualLessons.ToList();
            }
            else if (Shell.Current.CurrentItem.CurrentItem.Title == "Наступний тиждень")
            {
                IEnumerable<IndividualLesson> individualLessons = await scheduleService.GetLessonsForNextWeekAsync();
                Items = individualLessons.ToList();
            }
        }

        [RelayCommand]
        private async Task Details(int id)
        {
            await Shell.Current.GoToAsync(nameof(ScheduleDetailPage));
        }
    }
}
