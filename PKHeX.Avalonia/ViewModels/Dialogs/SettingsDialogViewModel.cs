namespace PKHeX.Avalonia.ViewModels.Dialogs;

public class SettingsDialogViewModel : DialogViewModelBase
{
    private bool _isModified;
    private int _selectedTab;

    public SettingsDialogViewModel()
    {
        _isModified = false;
        _selectedTab = 0;
    }
}
