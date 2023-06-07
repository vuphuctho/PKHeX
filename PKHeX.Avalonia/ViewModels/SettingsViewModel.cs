using PKHeX.Avalonia.BusinessLogics;
using PKHeX.Avalonia.Models;
using ReactiveUI.Fody.Helpers;

namespace PKHeX.Avalonia.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    private readonly ISettingsProvider _settingsProvider;

    public SettingsViewModel(
        ISettingsProvider settingsProvider)
    {
        _settingsProvider = settingsProvider;
        Settings = settingsProvider.Load();
    }

    [Reactive] public AppSettings Settings { get; set; }
}
