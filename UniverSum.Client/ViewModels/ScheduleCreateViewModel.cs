using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniverSum.API.Models;
using UniverSum.API.Models.Schedule;
using UniverSum.Client.Services;

namespace UniverSum.Client.ViewModels
{
    public partial class ScheduleCreateViewModel : ObservableObject
    {
        [ObservableProperty]
        public IndividualLesson _item;

        [ObservableProperty]
        public string _title;

        [ObservableProperty]
        public DateTime _dateTime;

        [ObservableProperty]
        public List<Profile> _profiles;

        private readonly ScheduleService scheduleService;

        public ScheduleCreateViewModel()
        {
            scheduleService = new ScheduleService();
            var task = Task.Run(LoadItem);
            task.Wait();
        }

        private async void LoadItem()
        {
            IndividualLesson individualLesson = await scheduleService.GetLesson(0);
            Item = individualLesson;
        }

        [RelayCommand]
        private async Task Create()
        {
            await scheduleService.PutLessonAsync(
                new IndividualLesson
                {
                    RecurringLesson =
                new RecurringLesson
                {
                    StartDate = DateTime,
                    Course =
                new API.Models.Courses.Course { Title = Title },
                    Members = Profiles
                }
                });
        }
    }
}
