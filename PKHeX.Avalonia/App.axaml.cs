using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Xaml.Interactions.Core;
using Avalonia.Markup.Xaml;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia;
using PKHeX.Avalonia.BusinessLogics;
using PKHeX.Avalonia.Services;
using PKHeX.Avalonia.ViewModels;
using PKHeX.Avalonia.Views;
using Splat;

namespace PKHeX.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        var build = Locator.CurrentMutable;
        build.RegisterLazySingleton(() => (IDialogService)new DialogService(
            new DialogManager(
                viewLocator: new ViewLocator(),
                dialogFactory: new DialogFactory().AddMessageBox()),
            viewModelFactory: x => Locator.Current.GetService(x)));

        // ViewModels registration
        SplatRegistrations.Register<MainViewModel>();
        SplatRegistrations.Register<AboutViewModel>();
        SplatRegistrations.Register<SettingsViewModel>();

        // Services registration
        SplatRegistrations.Register<IEnvironmentService, EnvironmentService>();
        SplatRegistrations.Register<IFileSystemService, FileSystemService>();
        SplatRegistrations.Register<ISerializationService, SerializationService>();
        SplatRegistrations.Register<IAppUpdateService, AppUpdateService>();

        // BusinessLogics registration
        SplatRegistrations.Register<ISettingsProvider, SettingsProvider>();

        SplatRegistrations.SetupIOC();
    }

    public override void OnFrameworkInitializationCompleted()
    {
#if DEBUG
        // Required by Avalonia XAML editor to recognize custom XAML namespaces. Until they fix the problem.
        GC.KeepAlive(typeof(EventTriggerBehavior));

        if (Design.IsDesignMode)
        {
            base.OnFrameworkInitializationCompleted();
            return;
        }
#endif
        DialogService.Show(null, Main);

        base.OnFrameworkInitializationCompleted();
    }

    //TODO: Move to ViewModelLocator
    public static MainViewModel Main => Locator.Current.GetService<MainViewModel>()!;
    public static IDialogService DialogService => Locator.Current.GetService<IDialogService>()!;
    public static AboutViewModel About => Locator.Current.GetService<AboutViewModel>()!;
}