using System.Windows.Input;

namespace PKHeX.Avalonia.ViewModels;

public abstract class _OkCancelDialogViewModelBase : OkDialogViewModelBase
{
    public ICommand CancelCommand { get; }
    protected abstract void Cancel();
}
