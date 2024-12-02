using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniverSum.Client.Models;

namespace UniverSum.Client.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        LocalDatabase localDatabase;

        [ObservableProperty]
        private string _selectedTheme = "Light";
        [ObservableProperty]
        private string _selectedLanguage = "Ukrainian";
        [ObservableProperty]
        private string _selectedLinkOpening = "InApp";
        [ObservableProperty]
        private string _feedback;

        public SettingsViewModel()
        {
            localDatabase = new LocalDatabase();
        }

        [RelayCommand]
        private void Save()
        {
            localDatabase.SaveSettingAsync(new Setting { Title = "Theme", Value = SelectedTheme});
            localDatabase.SaveSettingAsync(new Setting { Title = "Language", Value = SelectedLanguage});
            localDatabase.SaveSettingAsync(new Setting { Title = "Browser", Value = SelectedLinkOpening});
        }

        [RelayCommand]
        private void SubmitFeedback()
        {
            // TODO: Написати контролер і сервіс для зворотнього зв'язку.
        }
    }
}
