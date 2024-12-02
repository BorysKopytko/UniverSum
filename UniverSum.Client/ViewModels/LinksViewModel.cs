using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniverSum.API.Models;
using UniverSum.Client.Services;

namespace UniverSum.Client.ViewModels
{
    public partial class LinksViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<Link> _items;

        private readonly LinkService linkService;

        public LinksViewModel()
        {
            linkService = new LinkService();
            var task = Task.Run(LoadItems);
            task.Wait();
        }

        private async Task LoadItems()
        {
            if (Shell.Current.CurrentItem.CurrentItem.Title == "Улюблені")
            {
                IEnumerable<Link> links = await linkService.GetLinksByFavorite();
                Items = links.ToList();
            }
            else if (Shell.Current.CurrentItem.CurrentItem.Title == "Усі")
            {
                IEnumerable<Link> links = await linkService.GetLinksByCategory("all");
                Items = links.ToList();
            }
            else if (Shell.Current.CurrentItem.CurrentItem.Title == "Факультетські")
            {
                IEnumerable<Link> links = await linkService.GetLinksByCategory("faculty");
                Items = links.ToList();
            }
            else if (Shell.Current.CurrentItem.CurrentItem.Title == "Університетські")
            {
                IEnumerable<Link> links = await linkService.GetLinksByCategory("university");
                Items = links.ToList();
            }
        }

        [RelayCommand]
        private async Task Open(Uri url)
        {
            await Launcher.OpenAsync(url);
        }
    }
}
