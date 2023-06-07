using System.Threading.Tasks;

namespace PKHeX.Avalonia.BusinessLogics;

public interface IFileSystemService
{
    bool IsDirectory(string path);
    bool IsFile(string path);

    Task CreateFileAsync(string path);

    string ReadFile(string path);
    Task<string> ReadFileAsync(string path);

    Task WriteFileAsync(string path, string content);
}
