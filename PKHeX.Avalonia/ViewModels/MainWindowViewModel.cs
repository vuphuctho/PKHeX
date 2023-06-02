namespace PKHeX.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ToolbarViewModel Toolbar { get; }
    public MainWindowViewModel()
    {
        Toolbar = new ToolbarViewModel();
    }
}
