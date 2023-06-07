using System.Windows.Input;

namespace PKHeX.Avalonia.ViewModels;

public abstract class OkDialogViewModelBase : ViewModelBase
{
    public ICommand OkCommand { get; }
    protected abstract void Ok();
}
