using System.Text.Json;
using System.Threading.Tasks;

namespace PKHeX.Avalonia.BusinessLogics;

public interface ISerializationService
{
    Task SerializeToFileAsync<T>(string filePath, T content);
    T? DeserializeFromFile<T>(string filePath);
    Task<T?> DeserializeFromFileAsync<T>(string filePath);
}
