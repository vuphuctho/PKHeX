using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PKHeX.Avalonia.Views.Settings;

public partial class SpriteSettingsView : UserControl
{
    public SpriteSettingsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}

