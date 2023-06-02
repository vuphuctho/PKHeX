using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PKHeX.Avalonia.Views.Dialogs;

public partial class AboutDialogWindow : Window
{
    public AboutDialogWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}

