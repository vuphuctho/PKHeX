using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PKHeX.Avalonia.Views.Settings;

public partial class MysteryDbSettingsView : UserControl
{
    public MysteryDbSettingsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}

