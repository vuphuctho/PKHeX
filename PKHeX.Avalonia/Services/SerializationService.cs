using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace PKHeX.Avalonia.BusinessLogics;

public class SerializationService : ISerializationService
{
    private readonly IFileSystemService _fileSystemService;

    public SerializationService(IFileSystemService fileSystemService)
    {
        _fileSystemService = fileSystemService;
    }

    private JsonSerializerOptions GetOptions(IJsonTypeInfoResolver? serializerContext)
    {
        return new()
        {
            TypeInfoResolver = serializerContext,
            IgnoreReadOnlyFields = true,
            WriteIndented = false,
        };
    }

    public async Task SerializeToFileAsync<T>(string filePath, T content)
    {
        var contentStr = JsonSerializer.Serialize(content, GetOptions(null));
        await _fileSystemService.WriteFileAsync(filePath, contentStr);
        return;
    }

    public T? DeserializeFromFile<T>(string filePath)
    {
        if (!_fileSystemService.IsFile(filePath))
            throw new FileNotFoundException();

        var contentStr = _fileSystemService.ReadFile(filePath);
        var content = JsonSerializer.Deserialize<T>(contentStr);

        return content;
    }
    public async Task<T?> DeserializeFromFileAsync<T>(string filePath)
    {
        if (!_fileSystemService.IsFile(filePath))
            throw new FileNotFoundException();

        var contentStr = await _fileSystemService.ReadFileAsync(filePath);
        var content = JsonSerializer.Deserialize<T>(contentStr);

        return content;
    }
}
