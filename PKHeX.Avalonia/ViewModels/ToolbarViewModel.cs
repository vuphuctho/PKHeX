using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using PKHeX.Avalonia.ViewModels.Dialogs;
using PKHeX.Avalonia.Views.Dialogs;
using ReactiveUI;

namespace PKHeX.Avalonia.ViewModels;

public class ToolbarViewModel : ViewModelBase
{
    public ToolbarViewModel()
    {
        OpenCommand = ReactiveCommand.CreateFromTask(async () => await OnOpen());
        SaveCommand = ReactiveCommand.CreateFromTask(async () => await OnSave());
        ExportCommand = ReactiveCommand.CreateFromTask(async () => await OnExport());
        ExitCommand = ReactiveCommand.Create(OnExit);

        ShowSettingsDialogCommand = ReactiveCommand.Create(OnShowSettingsDialog);
        ShowAboutDialogCommand = ReactiveCommand.CreateFromTask(async () => await OnShowAboutDialog());
    }

    #region File Menu
    public ICommand OpenCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand ExportCommand { get; }

    public ICommand ExitCommand { get; }

    private async Task OnOpen()
    {
        //TODO: open file, validate, handle validation results
    }

    private async Task OnSave()
    {
        //TODO: save file
    }

    private async Task OnExport()
    {
        //TODO: export file
    }

    private async Task OnExit()
    {
        //TODO: add check for unsaved changes
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopApp)
            desktopApp.Shutdown();
    }
    #endregion

    #region Tools Menu
    /*public ICommand LoadBoxes { get; }
    public ICommand DumpBoxes { get; }
    public ICommand DumpBox { get; }
    public ICommand ReportBoxData { get; }
    public ICommand OpenMainMenuDatabase { get; }
    public ICommand OpenMysteryGiftDatabase { get; }
    public ICommand OpenEncounterDatabase { get; }
    public ICommand OpenBatchEditor { get; }
    public ICommand OpenFolder { get; }*/
    #endregion

    #region Options Menu
    /*public ICommand Undo { get; }
    public ICommand Redo { get; }*/
    public ICommand ShowSettingsDialogCommand { get; }
    public ICommand ShowAboutDialogCommand { get; }

    private void OnShowSettingsDialog()
    {

    }

    private async Task OnShowAboutDialog()
    {
        var aboutWindow = new AboutDialogWindow();
        await aboutWindow.ShowDialog<AboutDialogViewModel>(aboutWindow);
    }
    #endregion
}
