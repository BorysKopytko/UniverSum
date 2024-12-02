using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniverSum.API.Models.Conversations;
using UniverSum.API.Models.Schedule;
using UniverSum.Client.Pages;
using UniverSum.Client.Services;

namespace UniverSum.Client.ViewModels
{
    public partial class ConversationsViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<Conversation> _items;

        private readonly ConversationService conversationService;

        public ConversationsViewModel()
        {
            conversationService = new ConversationService();
            var task = Task.Run(LoadItems);
            task.Wait();
        }

        private async Task LoadItems()
        {
            IEnumerable<Conversation> conversations = await conversationService.GetConversationsAsync();
            Items = conversations.ToList();
        }

        [RelayCommand]
        private async Task Details(int id)
        {
            await Shell.Current.GoToAsync(nameof(ConversationDetailPage));
        }
    }
}
