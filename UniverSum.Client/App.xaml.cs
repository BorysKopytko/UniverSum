using UniverSum.Client.Pages;

namespace UniverSum.Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(ScheduleDetailPage), typeof(ScheduleDetailPage));
            Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));
            Routing.RegisterRoute(nameof(CourseDetailPage), typeof(CourseDetailPage));
            Routing.RegisterRoute(nameof(ConversationDetailPage), typeof(ConversationDetailPage));

            MainPage = new LoginShell();
        }
    }
}
