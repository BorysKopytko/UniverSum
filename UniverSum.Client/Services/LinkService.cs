using UniverSum.API.Models;
using UniverSum.API.Models.Courses;

namespace UniverSum.Client.Services;

internal class LinkService
{
    private string ApiUrlBase = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7023/" : "https://localhost:7023/";

    private readonly RequestService _requestService;

    public LinkService()
    {
        _requestService = new RequestService();
    }

    public async Task<IEnumerable<Link>> GetLinksByCategory(string category)
    {
        var uri = $"{ApiUrlBase}api/Links/linkcategory/{category}";

        IEnumerable<Link> links = await _requestService.GetAsync<IEnumerable<Link>>(uri).ConfigureAwait(false);

        return links?.ToArray() ?? Enumerable.Empty<Link>();
    }

    public async Task<IEnumerable<Link>> GetLinksByFavorite()
    {
        var uri = $"{ApiUrlBase}api/Links/linksfavorite";

        IEnumerable<Link> links = await _requestService.GetAsync<IEnumerable<Link>>(uri).ConfigureAwait(false);

        return links?.ToArray() ?? Enumerable.Empty<Link>();
    }
}
