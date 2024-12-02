using CommunityToolkit.Mvvm.ComponentModel;
using UniverSum.API.Models.Schedule;
using UniverSum.Client.Services;

namespace UniverSum.Client.ViewModels
{
    public partial class ScheduleDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        public IndividualLesson _item;

        private readonly ScheduleService scheduleService;

        public ScheduleDetailViewModel()
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
    }
}
