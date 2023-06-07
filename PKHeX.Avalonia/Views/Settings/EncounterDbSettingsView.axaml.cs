using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PKHeX.Avalonia.Views.Settings;

public partial class EncounterDbSettingsView : UserControl
{
    public EncounterDbSettingsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}

