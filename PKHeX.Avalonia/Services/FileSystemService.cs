using System.IO;
using System.Threading.Tasks;
using PKHeX.Avalonia.BusinessLogics;

namespace PKHeX.Avalonia.Services;

public class FileSystemService : IFileSystemService
{
    public FileSystemService()
    {

    }


    public bool IsDirectory(string path)
    {
        return Directory.Exists(path);
    }

    public bool IsFile(string path)
    {
        return File.Exists(path);
    }

    public async Task CreateFileAsync(string path)
    {
        if (IsFile(path))
            return;
        File.Create(path);
    }

    public string ReadFile(string path)
    {
        if (!IsFile(path))
            throw new FileNotFoundException();
        var content = File.ReadAllText(path);
        return content;
    }

    public async Task<string> ReadFileAsync(string path)
    {

        if (!IsFile(path))
            throw new FileNotFoundException();
        var content = await File.ReadAllTextAsync(path);
        return content;
        throw new System.NotImplementedException();
    }

    public async Task WriteFileAsync(string path, string content)
    {
        if (!IsFile(path))
            await CreateFileAsync(path);

        await File.WriteAllTextAsync(path, content);
        return;
    }
}
