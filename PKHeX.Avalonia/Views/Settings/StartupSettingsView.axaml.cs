using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PKHeX.Avalonia.Views.Settings;

public partial class StartupSettingsView : UserControl
{
    public StartupSettingsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}

