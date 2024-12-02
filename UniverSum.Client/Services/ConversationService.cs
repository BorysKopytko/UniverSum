using UniverSum.API.Models.Conversations;

namespace UniverSum.Client.Services;

internal class ConversationService
{
    private string ApiUrlBase = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7023/" : "https://localhost:7023/";

    private readonly RequestService _requestService;

    public ConversationService()
    {
        _requestService = new RequestService();
    }

    public async Task<Conversation> GetConversationAsync(int id)
    {
        var uri = $"{ApiUrlBase}api/Conversation/conversation/{id}";

        Conversation conversation = await _requestService.GetAsync<Conversation>(uri).ConfigureAwait(false);

        return conversation ?? null;
    }

    public async Task<IEnumerable<Conversation>> GetConversationsAsync()
    {
        var uri = $"{ApiUrlBase}api/Conversation/conversations";

        IEnumerable<Conversation> conversations = await _requestService.GetAsync<IEnumerable<Conversation>>(uri).ConfigureAwait(false);

        return conversations?.ToArray() ?? Enumerable.Empty<Conversation>();
    }
}
