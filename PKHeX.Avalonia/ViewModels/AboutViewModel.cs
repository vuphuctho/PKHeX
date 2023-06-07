using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Platform;
using ReactiveUI.Fody.Helpers;

namespace PKHeX.Avalonia.ViewModels;

public class AboutViewModel : ViewModelBase
{
    private const string ChangelogUri = "avares://PKHeX.Avalonia/Assets/text/changelog.txt";
    private const string ShortcutUri = "avares://PKHeX.Avalonia/Assets/text/shortcuts.txt";
    public AboutViewModel()
    {
        Errors = new();
        ChangelogText = LoadAssets(ChangelogUri);
        ShortcutText = LoadAssets(ShortcutUri);
    }

    private List<string> Errors { get; }

    public string ErrorStr => string.Join("\n", Errors);
    public string ChangelogText { get; }
    public string ShortcutText { get; }

    private string LoadAssets(string assetPath)
    {
        try
        {
            var uri = new Uri(assetPath);
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            if (!assets.Exists(uri))
                throw new FileNotFoundException();
            var stream = assets.Open(new Uri(assetPath));
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
        catch (Exception e)
        {
            Errors.Add(e.Message);
            return string.Empty;
        }
    }
}
