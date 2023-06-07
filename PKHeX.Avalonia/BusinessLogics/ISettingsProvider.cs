using PKHeX.Avalonia.Models;

namespace PKHeX.Avalonia.BusinessLogics;

public interface ISettingsProvider
{
    AppSettings Load();
    bool Save();
    AppSettings GetDefault();
}
