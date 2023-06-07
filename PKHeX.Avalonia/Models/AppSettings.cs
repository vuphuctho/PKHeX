using System.ComponentModel.DataAnnotations;
using PKHeX.Avalonia.Enums;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace PKHeX.Avalonia.Models;

public class AppSettings : ReactiveObject
{
    [EnumDataType(typeof(SupportedLanguage))]
    [Reactive] public SupportedLanguage Language { get; set; } = SupportedLanguage.English;
}
