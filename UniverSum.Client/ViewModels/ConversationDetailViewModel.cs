using CommunityToolkit.Mvvm.ComponentModel;
using UniverSum.API.Models.Conversations;
using UniverSum.Client.Services;

namespace UniverSum.Client.ViewModels
{
    public partial class ConversationDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        public Conversation _item;

        private readonly ConversationService conversationService;

        public ConversationDetailViewModel()
        {
            conversationService = new ConversationService();
            var task = Task.Run(LoadItem);
            task.Wait();
        }

        private async void LoadItem()
        {
            var task = await conversationService.GetConversationAsync(0);
            Item = task;
        }
    }
}
