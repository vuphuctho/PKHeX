using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DynamicData.Binding;
using HanumanInstitute.MvvmDialogs;
using PKHeX.Avalonia.BusinessLogics;
using PKHeX.Avalonia.Enums;
using PKHeX.Avalonia.Models;
using PKHeX.Avalonia.Utils;
using Projektanker.Icons.Avalonia;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace PKHeX.Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly ISettingsProvider _settingsProvider;
    private readonly IDialogService _dialogService;
    public MainViewModel(
        ISettingsProvider settingsProvider,
        IDialogService dialogService)
    {
        _settingsProvider = settingsProvider;
        _dialogService = dialogService;
        ShowAboutCommand = ReactiveCommand.Create(ShowAbout);
        ShowSettingsCommand = ReactiveCommand.Create(ShowSettings);
        SelectLanguageCommand = ReactiveCommand.Create<SupportedLanguage>(SelectLanguage);

        _languageMenuItems = this.WhenAnyValue(x => x.Settings.Language)
            .Select(GetLanguageMenuItems)
            .ToProperty(this, x => x.LanguageMenuItems);

        Settings = _settingsProvider.Load();
    }
    [Reactive]
    public AppSettings Settings { get; set; }

    private ObservableAsPropertyHelper<IReadOnlyList<MenuItemViewModel>> _languageMenuItems;
    public IReadOnlyList<MenuItemViewModel> LanguageMenuItems => _languageMenuItems.Value;
    private ReactiveCommand<SupportedLanguage, Unit> SelectLanguageCommand { get; }

    private void SelectLanguage(SupportedLanguage language)
    {
        Settings.Language = language;
    }

    private List<MenuItemViewModel> GetLanguageMenuItems(SupportedLanguage selected)
    {
        return Enum
            .GetValues(typeof(SupportedLanguage))
            .Cast<SupportedLanguage>()
            .Select((lang) => new MenuItemViewModel()
            {
                Header = lang.GetDisplayName() ?? string.Empty,
                Command = SelectLanguageCommand,
                CommandParameter = lang,
                Icon = lang == selected ? "fa-check" : string.Empty
            })
            .ToList();
    }

    public ICommand ShowAboutCommand { get; }
    private void ShowAbout()
    {
        var aboutViewModel = _dialogService.CreateViewModel<AboutViewModel>();
        _dialogService.Show(this, aboutViewModel);
    }

    public ICommand ShowSettingsCommand { get; }

    private void ShowSettings()
    {
        var settingsViewModel = _dialogService.CreateViewModel<SettingsViewModel>();
        _dialogService.Show(this, settingsViewModel);
    }
}
