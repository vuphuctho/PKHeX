using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using HanumanInstitute.MvvmDialogs;
using ReactiveUI;

namespace PKHeX.Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IDialogService _dialogService;
    public MainViewModel(
        IDialogService dialogService)
    {
        this._dialogService = dialogService;
        ShowAboutCommand = ReactiveCommand.Create(ShowAbout);
    }

    public ICommand ShowAboutCommand;

    private void ShowAbout()
    {
        var aboutViewModel = _dialogService.CreateViewModel<AboutViewModel>();
        _dialogService.Show(this, aboutViewModel);
    }
}
