using System.ComponentModel;
using System.Threading.Tasks;

namespace PKHeX.Avalonia.Services;

public interface IAppUpdateService
{
    /// <summary>
    /// Checks for updates based on application settings and offers to open a download link if available.
    /// </summary>
    Task CheckForUpdatesAsync(INotifyPropertyChanged owner);
}
